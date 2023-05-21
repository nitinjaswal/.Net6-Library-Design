import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject, debounceTime, map } from 'rxjs';
import { BookISBN } from 'src/app/_models/bookisbn';
import { BookMasterList } from 'src/app/_models/bookmasterlist';
import { IssueBook } from 'src/app/_models/issue-book.model';
import { User } from 'src/app/_models/user';
import { BooksIssueService } from 'src/app/_services/books-issue.service';
import { BooksService } from 'src/app/_services/books-service';
import { UserService } from 'src/app/_services/user-service';

@Component({
  selector: 'app-book-issue',
  templateUrl: './book-issue.component.html',
  styleUrls: ['./book-issue.component.css'],
})
export class BookIssueComponent implements OnInit {
  issueBookForm: FormGroup;
  users: User[] = [];
  isbn: BookISBN[] = [];
  selectedISBN: string;
  selectedUser: number;
  bookMasterList: BookMasterList[] = [];
  totalBooksIssued: number;

  results$: Observable<any>;
  subject = new Subject();
  
  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private bookIssueService: BooksIssueService,
    private bookService: BooksService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getISBNs();
    this.getUsers();
    
    this.results$ = this.subject.pipe(
      debounceTime(4000),
      map((searchText) => this.getUsers())
    );
  }

  isbnSearchKeyword = 'isbn';
  userSearchKeyword = 'email';

  initializeForm() {
    this.issueBookForm = this.fb.group({
      userId: ['', [Validators.required]],
      masterbookId: ['', [Validators.required]],
    });
  }

  getISBNs() {
    this.bookService.getISBNs().subscribe((data) => {
      this.isbn = data;
    });
  }

  getUsers() {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
      console.log(this.users);
    });
  }

  getMasterBooks() {
    this.bookService.getMasterBooks().subscribe((list) => {
      this.bookMasterList = list;
    });
  }

  protected get registerIssueBookControl() {
    return this.issueBookForm.controls;
  }

  selectISBN(item) {
    this.selectedISBN = item.isbn;
  }

  onChangeSearch(search: string) {}

  selectUser(item) {
    this.selectedUser = item.id;
    this.getUserBooksPosssessionCount(this.selectedUser);
  }

  onUserChangeSearch(search: string) {
    this.getUserBooksPosssessionCount(this.selectedUser);
  }

  getUserBooksPosssessionCount(userId: number) {
    this.bookIssueService
      .getUserBooksPosssessionCount(this.selectedUser)
      .subscribe((data) => {
        this.totalBooksIssued = data;
        if (this.totalBooksIssued >= 2) {
          this.toastr.warning('Maximum book issue limit is reached.');
        }
      });
  }

  issueBook() {
    let model = new IssueBook();
    debugger;
    model.UserId = this.selectedUser;
    model.ISBN = this.selectedISBN;

    this.bookIssueService.issueBook(model).subscribe({
      next: (res) => {
        console.log(res);
        this.toastr.success('Book issued successfully.');
        this.issueBookForm.reset();
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
        this.toastr.error('Something went wrong.');
      },
    });
  }
}

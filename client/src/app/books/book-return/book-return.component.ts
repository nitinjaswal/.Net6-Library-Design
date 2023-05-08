import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject, debounce, debounceTime, map } from 'rxjs';
import { BookISBN } from 'src/app/_models/bookisbn';
import { IssueBook } from 'src/app/_models/issue-book.model';
import { User } from 'src/app/_models/user';
import { BookReturnService } from 'src/app/_services/book-return.service';
import { BooksService } from 'src/app/_services/books-service';
import { UserService } from 'src/app/_services/user-service';

@Component({
  selector: 'app-book-return',
  templateUrl: './book-return.component.html',
  styleUrls: ['./book-return.component.css'],
})
export class BookReturnComponent implements OnInit {
  returnBookForm: FormGroup;
  users: User[] = [];
  isbn: BookISBN[] = [];
  selectedISBN: string;
  selectedUser: number;
  isFineExist: boolean = false;
  userEmail: string;
  userName: string;
  issuedDate: Date;
  isISBNSelected: boolean = false;
  isbnSearchKeyword = 'isbn';
  userSearchKeyword = 'email';

  results$: Observable<any>;
  subject = new Subject();

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private bookReturnService: BookReturnService,
    private bookService: BooksService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getISBNs();
    this.results$ = this.subject.pipe(
      debounceTime(4000),
      map((searchText) => this.bookTransactionDetail(searchText))
    );
  }

  initializeForm() {
    this.returnBookForm = this.fb.group({
      ISBN: ['', [Validators.required]],
    });
  }

  getISBNs() {
    this.bookService.getISBNs().subscribe((data) => {
      this.isbn = data;
    });
  }

  selectISBN(item) {
    this.bookTransactionDetail(item.isbn);
  }

  onChangeSearch(search: string) {
    const searchText = search;
    this.subject.next(searchText);
    // this.bookTransactionDetail(search);
  }

  bookTransactionDetail(ISBN: any) {
    this.selectedISBN = ISBN;
    this.bookReturnService.bookTransactionDetail(ISBN).subscribe((data) => {
      debugger;
      if (data != null) {
        this.userEmail = data.email;
        this.userName = data.name;
        this.issuedDate = data.issuedDate;
        this.isFineExist = data.isFineExist;
        this.isISBNSelected = true;
      } else {
        this.isISBNSelected = false;
        this.toastr.error('Selected ISBN is not issued yet');
      }
    });
  }

  selectUser(item) {
    this.selectedUser = item.id;
  }

  returnBook() {
    let model = new IssueBook();
    debugger;
    model.ISBN = this.selectedISBN;

    this.bookReturnService.returnBook(this.selectedISBN).subscribe({
      next: (res) => {
        console.log(res);
        this.toastr.success('Book returned successfully.');
        this.returnBookForm.reset();
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
        this.toastr.error('Something went wrong.');
      },
    });
  }

  protected get registerReturnBookControl() {
    return this.returnBookForm.controls;
  }
}

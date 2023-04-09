import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BookMasterList } from 'src/app/_models/bookmasterlist';
import { User } from 'src/app/_models/user';
import { BooksService } from 'src/app/_services/books.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-book-issue',
  templateUrl: './book-issue.component.html',
  styleUrls: ['./book-issue.component.css'],
})
export class BookIssueComponent implements OnInit {
  issueBookForm: FormGroup;
  users: User[] = [];
  bookMasterList: BookMasterList[] = [];

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private bookService: BooksService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getUsers();
    this.getMasterBooks();
  }

  initializeForm() {
    this.issueBookForm = this.fb.group({
      userId: ['', [Validators.required]],
      masterbookId: ['', [Validators.required]],
    });
  }

  getUsers() {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
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

  issueBook() {
    this.bookService.issueBook(this.issueBookForm.value).subscribe({
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

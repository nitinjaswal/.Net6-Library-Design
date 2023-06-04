import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Book } from 'src/app/_models/book';
import { RequestBook } from 'src/app/_models/request-book';
import { AccountService } from 'src/app/_services/account-service';
import { BooksService } from 'src/app/_services/books-service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css'],
})
export class BookDetailComponent implements OnInit {
  bookId: number;
  book: Book;
  baseUrl = environment.imageBaseUrl;
  /**
   *
   */
  constructor(
    private bookService: BooksService,
    private accountService: AccountService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getBookDetail();
  }

  user: any;

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: (user) => (this.user = user),
      error: (error) => console.log(error),
    });
  }

  getBookDetail() {
    this.bookId = parseInt(this.route.snapshot.paramMap.get('id'));
    this.bookService.getBooKDetail(this.bookId).subscribe((response) => {
      this.book = response;
    });
  }

  requestBook() {
    let requestBookModel = new RequestBook();
    requestBookModel.ISBN = this.book.isbn;
    requestBookModel.UserId = 2;
    requestBookModel.RequestStatus = 'Awaiting Confirmation';
    requestBookModel.IsOnlineRequest = true;

    this.bookService.createBookRequest(requestBookModel).subscribe({
      next: (res) => {
        console.log(res);
        this.toastr.success('Book Request created successfully.');
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
        this.toastr.error('Something went wrong.');
      },
    });
  }
}

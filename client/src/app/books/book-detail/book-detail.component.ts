import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css'],
})
export class BookDetailComponent implements OnInit {
  bookId: number;
  /**
   *
   */
  constructor(
    private bookService: BooksService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getBookDetail();
  }

  getBookDetail() {
    debugger;
    this.bookId = parseInt(this.route.snapshot.paramMap.get('id'));

    this.bookService.getBooKDetail(this.bookId).subscribe((response) => {
      console.log(response);
    });
  }
}

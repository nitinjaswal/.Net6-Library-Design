import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { Status } from 'src/app/_models/status';
import { Type } from 'src/app/_models/type';
import { BooksService } from 'src/app/_services/books-service';
import { ToastrService } from 'ngx-toastr';
import { BookMasterList } from 'src/app/_models/bookmasterlist';
import {
  HttpDownloadProgressEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { BookCreateService } from 'src/app/_services/book-create.service';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css'],
})
export class BookCreateComponent implements OnInit {
  categories: Category[] = [];
  type: Type[] = [];
  statuses: Status[] = [];
  bookMasterList: BookMasterList[] = [];

  createBookForm: FormGroup;
  createISBNForm!: FormGroup;

  selectedFile: File;
  isDirty = true;
  constructor(
    private bookService: BooksService,
    private bookCreateService: BookCreateService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getBookCategories();
    this.getBookStatus();
    this.getBookTypes();
    this.initializeISBNForm();
    this.getMasterBooks();
  }

  initializeForm() {
    this.createBookForm = this.fb.group({
      title: ['', [Validators.required]],
      publisher: ['', [Validators.required]],
      author: ['', [Validators.required]],
      totalpages: ['', [Validators.required]],
      description: ['', [Validators.required]],
      booktype: ['', [Validators.required]],
      bookcategory: ['', [Validators.required]],
      bookImage: ['', [Validators.required]],
    });
  }

  initializeISBNForm() {
    this.createISBNForm = this.fb.group({
      masterbook: ['', [Validators.required]],
      bookstatus: ['', [Validators.required]],
      isbn: ['', [Validators.required]],
    });
  }

  getBookCategories() {
    this.bookService.getCategories().subscribe((categories) => {
      this.categories = categories;
    });
  }

  getBookTypes() {
    this.bookService.getType().subscribe((type) => {
      this.type = type;
    });
  }

  getBookStatus() {
    this.bookService.getStatus().subscribe((status) => {
      this.statuses = status;
    });
  }

  getMasterBooks() {
    this.bookService.getMasterBooks().subscribe((list) => {
      this.bookMasterList = list;
    });
  }

  chooseFile(files: FileList) {
    // ...
    this.selectedFile = files[0];
  }

  onSubmit() {
    const formData = new FormData();

    formData.append('Title', this.createBookForm.controls['title'].value);
    formData.append(
      'Publisher',
      this.createBookForm.controls['publisher'].value
    );
    formData.append('Author', this.createBookForm.controls['author'].value);
    formData.append(
      'TotalPages',
      this.createBookForm.controls['totalpages'].value
    );
    formData.append(
      'Description',
      this.createBookForm.controls['description'].value
    );
    formData.append('BookType', this.createBookForm.controls['booktype'].value);
    formData.append(
      'BookCategory',
      this.createBookForm.controls['bookcategory'].value
    );
    formData.append('BookImage', this.selectedFile);

    console.log(formData);
    this.bookCreateService.createBookMaster(formData).subscribe({
      next: (res) => {
        this.toastr.success('Master book created successfully.');
        this.createBookForm.reset();
        this.getMasterBooks();
      },
      error: (error: HttpErrorResponse) => {
        this.toastr.error('Master book already exist.');
      },
    });
  }

  onSubmitISBN() {
    this.bookCreateService.createBookISBN(this.createISBNForm.value).subscribe({
      next: (res) => {
        console.log(res);
        this.toastr.success('Book ISBN created successfully.');
        this.createISBNForm.reset();
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
        this.toastr.error('ISBN already exists.');
      },
    });
  }

  protected get registerFormControl() {
    return this.createBookForm.controls;
  }

  protected get registerISBNFormControl() {
    return this.createISBNForm.controls;
  }
}

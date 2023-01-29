import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  NonNullableFormBuilder,
  Validators,
} from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { Status } from 'src/app/_models/status';
import { Type } from 'src/app/_models/type';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css'],
})
export class BookCreateComponent implements OnInit {
  categories: Category[] = [];
  type: Type[] = [];
  status: Status[] = [];
  createBook!: FormGroup;
  submitted = false;
  constructor(private bookService: BooksService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getBookCategories();
    this.getBookStatus();
    this.getBookTypes();
  }

  initializeForm() {
    this.createBook = this.fb.group({
      title: ['', [Validators.required]],
      publisher: ['', [Validators.required]],
      author: ['', [Validators.required]],
      pages: ['', [Validators.required]],
      description: ['', [Validators.required]],
      bookimage:['',[Validators.required]],
      booktype:['',[Validators.required]],
      bookcategory:['',[Validators.required]]
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
      this.status = status;
    });
  }

  onSubmit() {
    this.submitted = true;
    console.log(this.createBook.value);
  }

  protected get registerFormControl() {
    return this.createBook.controls;
  }
}

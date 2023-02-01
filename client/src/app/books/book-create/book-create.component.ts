import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css'],
})
export class BookCreateComponent implements OnInit {
  categories: Category[] = [];
  type: Type[] = [];
  status: Status[] = [];
  createBookForm!: FormGroup;
  selectedFile!: File;
  isDirty = true;
  constructor(
    private bookService: BooksService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getBookCategories();
    this.getBookStatus();
    this.getBookTypes();
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

  // onFileChange(event: any) {
  //   let reader = new FileReader(); // HTML5 FileReader API
  //   let file = event.target.files[0];
  //   if (event.target.files.length > 0) {
  //     reader.readAsDataURL(file);

  //     // When file uploads set it to file formcontrol
  //     reader.onload = () => {
  //       // this.imageUrl = reader.result;
  //       this.createBookForm.patchValue({
  //         file: reader.result,
  //       });
  //     };
  //     this.selectedFile = event.target.files[0];
  //     console.log(this.selectedFile.name);

  //     // this.createBookForm.patchValue({
  //     //   fileSource: file,
  //     // });
  //   }
  // }

  onSubmit() {
    this.bookService
      .createBookMaster(this.createBookForm.value)
      .subscribe((data) => {
        console.log(data);

        this.toastr.success('Master book created successfully');
        this.createBookForm.reset();
      });
  }

  protected get registerFormControl() {
    return this.createBookForm.controls;
  }
}

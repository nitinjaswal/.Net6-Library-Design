import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../_models/book';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Type } from '../_models/type';
import { Status } from '../_models/status';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

  getBooks() {
    return this.httpClient.get<Book[]>(this.baseUrl + 'books');
  }

  getCategories(){
    return this.httpClient.get<Category[]>(this.baseUrl + 'books/categories');
  }

  getType(){
    return this.httpClient.get<Type[]>(this.baseUrl + 'books/type');
  }

  getStatus(){
    return this.httpClient.get<Status[]>(this.baseUrl + 'books/status');
  }

}

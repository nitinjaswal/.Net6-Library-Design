import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Book } from '../_models/book';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Type } from '../_models/type';
import { Status } from '../_models/status';
import { Observable, of } from 'rxjs';
import { BookMasterList } from '../_models/bookmasterlist';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      return of(result as T);
    };
  }

  getBooks() {
    return this.httpClient.get<Book[]>(this.baseUrl + 'GetBooks');
  }

  getCategories() {
    return this.httpClient.get<Category[]>(this.baseUrl + 'GetBooks/categories');
  }

  getType() {
    return this.httpClient.get<Type[]>(this.baseUrl + 'GetBooks/type');
  }

  getStatus() {
    return this.httpClient.get<Status[]>(this.baseUrl + 'GetBooks/status');
  }

  getMasterBooks() {
    return this.httpClient.get<BookMasterList[]>(
      this.baseUrl + 'GetBooks/getmasterbooks'
    );
  }

  getBooKDetail(bookId: number) {
    return this.httpClient.get<Book>(
      this.baseUrl + 'GetBooks/bookdetail?bookMasterId=' + bookId
    );
  }

  createBookMaster(model: any) {
    return this.httpClient.post(this.baseUrl + 'CreateBook/masterBook', model);
  }

  createBookISBN(model: any): Observable<any> {
    return this.httpClient.post(this.baseUrl + 'CreateBook/ISBN', model);
  }

  createBookRequest(model: any): Observable<any> {
    return this.httpClient.post(
      this.baseUrl + 'RequestBook/requestbook',
      model
    );
  }
}

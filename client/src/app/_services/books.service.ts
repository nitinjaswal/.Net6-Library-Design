import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Book } from '../_models/book';
import { environment } from 'src/environments/environment';
import { Category } from '../_models/category';
import { Type } from '../_models/type';
import { Status } from '../_models/status';
import { catchError, map, Observable, of } from 'rxjs';
import { BookMaster } from '../_models/bookmaster';
import { BookMasterList } from '../_models/bookmasterlist';
import { BookISBN } from '../_models/bookisbn';

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
    return this.httpClient.get<Book[]>(this.baseUrl + 'books');
  }

  getCategories() {
    return this.httpClient.get<Category[]>(this.baseUrl + 'books/categories');
  }

  getType() {
    return this.httpClient.get<Type[]>(this.baseUrl + 'books/type');
  }

  getStatus() {
    return this.httpClient.get<Status[]>(this.baseUrl + 'books/status');
  }

  getMasterBooks() {
    return this.httpClient.get<BookMasterList[]>(
      this.baseUrl + 'books/getmasterbooks'
    );
  }

  createBookMaster(model: any) {
    debugger;
    const options = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };

    return this.httpClient
      .post(this.baseUrl + 'Books/createBook', model);

  }

  createBookISBN(model: any): Observable<any> {
    debugger;

    return this.httpClient
      .post(this.baseUrl + 'Books/createBookISBN', model);
  }
}

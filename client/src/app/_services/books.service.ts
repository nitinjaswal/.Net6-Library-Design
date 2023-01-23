import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../_models/Book';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

  getBooks() {
    return this.httpClient.get<Book[]>(this.baseUrl + 'books');
  }
}

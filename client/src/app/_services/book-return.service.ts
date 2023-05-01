import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BookTransactionDetail } from '../_models/book-transaction';

@Injectable({
  providedIn: 'root',
})
export class BookReturnService {
  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

  bookTransactionDetail(ISBN: string) {
    return this.httpClient.get<BookTransactionDetail>(
      this.baseUrl + 'ReturnBook/BookTransactionDetail?ISBN=' + ISBN
    );
  }

  returnBook(model: any): Observable<any> {
    return this.httpClient.post(this.baseUrl + 'ReturnBook', model);
  }
}

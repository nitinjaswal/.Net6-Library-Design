import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BooksIssueService {
  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

  issueBook(model: any): Observable<any> {
    return this.httpClient.post(this.baseUrl + 'IssueBook', model);
  }

  getUserBooksPosssessionCount(userId: number): Observable<any> {
    return this.httpClient.get(
      this.baseUrl + 'IssueBook/UserBooksPosssessionCount?userId=' + userId
    );
  }
}

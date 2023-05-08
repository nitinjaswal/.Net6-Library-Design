import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookCreateService {

  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}

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

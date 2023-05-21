import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private httpClinet: HttpClient, private router: Router) {}

  login(model: any) {
    return this.httpClinet.post<User>(this.baseUrl + 'users/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  setCurrentUser(user: User) {
    debugger;
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  register(model: any): Observable<any> {
    return this.httpClinet.post(this.baseUrl + 'users/register', model).pipe(
      map((user: User) => {
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
    this.router.navigateByUrl('/');
  }
}

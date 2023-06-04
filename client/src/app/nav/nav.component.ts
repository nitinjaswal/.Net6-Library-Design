import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account-service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn = false;
  role: string;
  username: string;

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: (user) => {
        this.loggedIn = !!user;
        if (user) {
          this.username = user.name;
          this.role = user.role;
        }
      },
      error: (error) => console.log(error),
    });
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/books');
        this.loggedIn = true;
        const userString = JSON.parse(localStorage.getItem('user')!);
        this.username = userString.name;
        this.role = userString.role;
      },
      error: (error) => {
        this.toastr.error('Invalid Username or Password.');
        console.log(error);
      },
    });
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
    this.model.email = '';
    this.model.password = '';
  }
}

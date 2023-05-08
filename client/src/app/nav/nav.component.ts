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
  role: String;

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
      next: (user) => (this.loggedIn = !!user),
      error: (error) => console.log(error),
    });
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/books');
        this.loggedIn = true;
        const userString = JSON.parse(localStorage.getItem('user')!);
        debugger;
        if (userString.role == 'Admin') {
          this.role = 'Admin';
        } else {
          this.role = 'Student';
        }
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

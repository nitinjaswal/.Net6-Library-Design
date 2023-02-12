import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  users: any;

  constructor(private acountService: AccountService) {}
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    debugger;
    const userString = JSON.parse(localStorage.getItem('user')!);

    if (!userString) return;

    const user: User = JSON.parse(userString);
    this.acountService.setCurrentUser(user);
  }
}

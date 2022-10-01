import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountsService } from './accounts/accounts.service';
import { IUser } from './shared/Models/user.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'client';
  constructor(private accountService: AccountsService, private router: Router) { }
  ngOnInit(): void {
    this.loadCurrentUser();
  }
  loadCurrentUser(): void {
    // debugger
    const storageUser = localStorage.getItem('user');
    if (storageUser) {
       const user = JSON.parse(storageUser);
      if (this.accountService.isTokenExpare(user.token)) {
        this.router.navigateByUrl('/account/signin');
      } else {
        this.accountService.setCurrentUser(user);
      }
    }

  }
}

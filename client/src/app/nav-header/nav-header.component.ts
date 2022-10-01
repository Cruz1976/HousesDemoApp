import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountsService } from '../accounts/accounts.service';
import { IUser } from '../shared/Models/user.interface';

@Component({
  selector: 'app-nav-header',
  templateUrl: './nav-header.component.html',
  styleUrls: ['./nav-header.component.css']
})
export class NavHeaderComponent implements OnInit {

  currentUser$: Observable<IUser> | undefined;
  userDetails: IUser | undefined;
  constructor(private accountService: AccountsService, private router: Router) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.accountService.currentUser$.subscribe(user => {
      this.userDetails = user;
      console.log(user);
    });
  }
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/account');
   }
}

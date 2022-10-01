import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, of, ReplaySubject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/Models/user.interface';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  baseUrl = environment.apiUrl;
 // url = environment.url;
  helper = new JwtHelperService();
  decodedToken: any;
  currentUser: IUser | undefined;
  private currentUserSource: ReplaySubject<IUser> = new ReplaySubject<IUser>(undefined);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private router: Router) { }



   isTokenExpare(token: string): boolean {
    const isExpired = this.helper.isTokenExpired(token);
    if (token === null ||  isExpired ) {
      this.currentUserSource.next(<IUser>{});
    }
     return isExpired;
   }
  // tslint:disable-next-line:typedef
  loadCurrentUser(token: string) {
    const isExpired = this.helper.isTokenExpired(token);
    debugger;
    if (token === null ||  isExpired ) {
      this.currentUserSource.next(<IUser>{});
      return of(null);
    }


    return this.http.get(this.baseUrl + 'Account').pipe(
      map((user) => {
        if (user) {
          this.currentUser = user as IUser;
          localStorage.setItem('token', this.currentUser.token);
         // this.decodedToken = this.jwtHelper.decodeToken(this.currentUser.token);
          this.currentUserSource.next(this.currentUser);
        }
      })
    );

  }

  // tslint:disable-next-line:typedef
  login(values: any) {
    return this.http.post(this.baseUrl + 'Account/login', values).pipe(
      map((user: any) => {
        if (user) {
          this.currentUser = user as IUser;
          localStorage.setItem('token', this.currentUser.token);
         // this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.setCurrentUser(this.currentUser);
          this.currentUserSource.next(this.currentUser);
          // this.presence.createHubConnection(user);
          return user;
        }
      })
    );
  }
  setCurrentUser(user: IUser): void {
    //user.roles = [];
    //const roles = this.getDecodedToken(user.token).role;
    //Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }
  getDecodedToken(token: string): any {
    return JSON.parse(atob(token.split('.')[1]));
  }
  // tslint:disable-next-line:typedef
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.currentUser = undefined;
    this.currentUserSource.next(<IUser>{});
    //this.router.navigateByUrl('accounta/signin');
    // this.presence.stopHubConnection();
  }
}

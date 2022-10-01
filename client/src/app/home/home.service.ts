import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, of, ReplaySubject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/Models/user.interface';
import { Agreement } from '../shared/Models/agreement';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = environment.apiUrl;
 // url = environment.url;
  helper = new JwtHelperService();
  decodedToken: any;
  currentUser: IUser | undefined;
  private currentUserSource: ReplaySubject<IUser> = new ReplaySubject<IUser>(undefined);
  currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient, private router: Router) { }

  getAgreements() {
   return this.http.get<Agreement[]>(this.baseUrl + 'Agreements')
  }

  // tslint:disable-next-line:typedef
  loadCurrentUser(token: string) {
    const isExpired = this.helper.isTokenExpired(token);
    debugger;
    if (token === null ||  isExpired ) {
      this.currentUserSource.next(<IUser>{ });
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


}

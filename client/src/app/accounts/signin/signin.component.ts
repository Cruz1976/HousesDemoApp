import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/shared/Models/user.interface';
import { AccountsService } from '../accounts.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  loginForm!: FormGroup
  returnUrl: string | undefined;
  currentUser$: Observable<IUser> | undefined;
  constructor(
    private accountService: AccountsService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required)
    });
  }
  onSubmit(): void {
    console.log(this.loginForm?.value);

    this.accountService.login(this.loginForm?.value).subscribe((user) => {
    //  console.log(user);
      this.router.navigateByUrl('/');
      //if (user.occupation === 'candidates') {
       // this.candidateManagerService.createHubConnection(user, 'candidate');
       // this.router.navigateByUrl('/');
       // }
    });
  }
  get email() {
    return this.loginForm.get('email');
  }
  get password() {
    return this.loginForm.get('password');
  }
}

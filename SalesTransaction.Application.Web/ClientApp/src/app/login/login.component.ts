import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators, NgForm, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, Routes } from '@angular/router';
import { fileURLToPath } from 'url';
import { LogInService } from './login.service';
import { MvLogin } from './login.model';



@Component({
  // tslint:disable-next-line: component-selector
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy, AfterViewInit {

  // tslint:disable-next-line: no-unused-expression
  loginForm: FormGroup;
  errorMessage: any;
  errorMessageType: any = {
    invForm: 'Invalid Form',
    invLogin: 'Invalid UserName or Password'
  };

  logInFormErrors: any = {
    userName: {},
    password: {}
  };

  login: MvLogin = <MvLogin>{};





  constructor(public fb: FormBuilder, public ls: LogInService,
    private snackBar: MatSnackBar,
    private router: Router

  ) { }



  ngOnInit() {

    this.loginForm = this.fb.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]

    });
    this.loginForm.valueChanges.subscribe(() => {
      this.onLoginFormChange();
    });

  }
  onLoginFormChange() {

    for (const field in this.logInFormErrors) {

      if (!this.logInFormErrors.hasOwnProperty(field)) {
        continue;
      }
      this.logInFormErrors[field] = {};
      const control = this.loginForm.get(field);

      if (control && control.dirty && !control.valid) {
        this.logInFormErrors[field] = control.errors;
      }
    }
  }

  submitForm() {
    this.errorMessage = null;
    if (this.loginForm.valid) {
      this.login.userName = this.loginForm.get('userName').value.trim();
      this.login.password = this.loginForm.get('password').value.trim();

      this.ls.getLogin(this.login).subscribe((response: any) => {

        if (response) {
          this.openSnackbar('Login successful!', 'success');
          this.router.navigate(['/user-detail']);
        } else {
          this.errorMessage = this.errorMessageType.invLogin;
        }
      });
    } else {
      this.errorMessage = this.errorMessageType.invForm;
    }
  }
  openSnackbar(message: string, action: string) {
    this.snackBar.open(message, 'close', {
      duration: 5000,
      panelClass: [action],
      horizontalPosition: 'end',
      verticalPosition: 'top',
    });
  }

  ngAfterViewInit(): void {
    this.loginForm.updateValueAndValidity();
  }
  ngOnDestroy(): void {

  }
}

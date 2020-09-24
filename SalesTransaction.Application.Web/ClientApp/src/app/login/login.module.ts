import { LoginComponent } from './login.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LogInService } from './login.service';
import { RouterModule, Routes } from '@angular/router';

import { from } from 'rxjs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { MatCommonModule } from '@angular/material/core';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  }
];


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarModule


  ],
  declarations: [
    LoginComponent
  ],
  providers: [
    LogInService

  ],
  exports: [
    LoginComponent

  ],
})
export class LoginModule { }

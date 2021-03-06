import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserDetailComponent } from './user-detail.component';
import { UserDetailService } from './user-detail.service';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: ':id',
    // path: '',
    component: UserDetailComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  declarations: [
    UserDetailComponent
  ],
  providers: [
    UserDetailService
  ],
  exports: [
    UserDetailComponent
  ]
})
export class UserDetailModule { }

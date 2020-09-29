import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'protractor';
import { UserDetailService } from './user-detail.service';
import { MvUserDetail } from './user-detail.model';
import { ActivatedRoute } from '@angular/router';
import { map, mergeMap } from 'rxjs/operators';


@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {

  displayedColumn: string[];
  dataSource: MvUserDetail[] = [];
  userMsg: string = null;


  constructor(
    // private http: HttpClient,
    // private uds: UserDetailService
    private userDetailService: UserDetailService,
    private route: ActivatedRoute

  ) { }

  ngOnInit() {
    this.displayedColumn = ['userId', 'userName', 'password', 'insertPersonId', 'insertDate'];
    this.getUserDetail();
  }


  getUserDetail(): void {
    this.route.params.pipe(
      map(res => {
        const id = res.id;
        return id;
      }), mergeMap(id => this.userDetailService.getUserDetail({ userId: id }))
    ).subscribe(res => {
      if (res) {
        this.dataSource = [res];
      } else {
        this.dataSource = [];
        this.userMsg = 'No data';
      }
    }, err => console.log(err));
  }

  getAllUsers(): void {
    this.userMsg = null;
    this.userDetailService.getAllUserDetail().subscribe(res => {
      if (res && res.data) {
        this.dataSource = res.data;
      } else {
        this.dataSource = [];
        this.userMsg = 'No Data';
      }
    }, err => console.log(err));
  }
  // getUserDetail() {
  //   this.userMsg = '';
  //   const headers = new HttpHeaders();
  //   headers.set('Content-Type', 'application/json');
  //   headers.set('Access-Control-Allow-Origin', '*');
  //   headers.set('Access-Control-Allow-Method', 'Get, Post');
  //   headers.set('Access-Control-Allow-Headers', 'Origin, Content-Type');

  //   this.http.get('http://localhost:5500/api/Account/UserDetail', {
  //     headers: headers,
  //     params: { json: JSON.stringify({ userId: id }) }
  //   }).subscribe((result: any) => {
  //     if (result) {
  //       this.dataSource = [result];
  //     } else {
  //       this.dataSource = [];
  //       this.userMsg = 'No Data';
  //     }
  //   }, err => console.error(error));

  // }

  // getAllUsers() {
  //   this.userMsg = '';
  //   this.uds.getAllUserDetail().subscribe((result: any) => {
  //     if (result && result.data) {
  //       this.dataSource = result.data;
  //     } else {
  //       this.dataSource = [];
  //       this.userMsg = 'No data';
  //     }
  //   });
  // }

}

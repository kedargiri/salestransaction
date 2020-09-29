import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
import { WebApiService } from 'src/core/services/web-api.service';
import { Observable } from 'rxjs/internal/Observable';
@Injectable({
    providedIn: 'root'
})

export class UserDetailService {
    constructor(private api: WebApiService) {

    }
    getUserDetail(json: any): Observable<any> {
        return this.api.get('Account/UserDetails', { json: JSON.stringify(json) });
    }

    getAllUserDetail(): Observable<any> {
        return this.api.get('Account/AllUserDetail');
    }
}

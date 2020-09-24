import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { WebApiService } from 'src/core/services/web-api.service';

@Injectable()
export class LogInService {
    constructor(private api: WebApiService) {
    }
    getLogin(json: any): Observable<any> {
        return this.api.post('Account/Login', json);
    }
}




import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from 'src/core/services/web-api.service';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    constructor(private api: WebApiService) {
    }

    getAllProducts(): Observable<any> {
        return this.api.get('/product/GetAllProductDetails');
    }

    addProduct(json: any): Observable<any> {
        return this.api.post('/Product/InsertProduct', json);
    }

    updateProduct(json: any): Observable<any> {
        return this.api.post('/Product/UpdateProduct', json);
    }
}

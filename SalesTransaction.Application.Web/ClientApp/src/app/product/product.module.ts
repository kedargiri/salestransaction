import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from './product.services';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../MaterialModules/M-Modules';
import { ProductFormComponent } from './Product-form/Product-form.component';



const routes: Routes = [
    { path: '', component: ProductComponent }
];

@NgModule({
    declarations: [ProductFormComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MaterialModule,
        RouterModule.forChild(routes)
    ],
    providers: [ProductService]
})
export class ProductModule { }

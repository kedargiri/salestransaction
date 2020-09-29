import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MvAddProduct } from '../product.model';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Product-form',
  templateUrl: './Product-form.component.html',
  styleUrls: ['./Product-form.component.scss']
})
export class ProductFormComponent implements OnInit {
  prodForm: FormGroup;
  prodCreateForm: FormGroup;
  prodEditForm: FormGroup;
  action: string;
  product: MvAddProduct = {} as MvAddProduct;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<ProductFormComponent>
  ) {
    this.action = data.action;
    this.product = data.data || {};
    dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    if (this.action === 'Add') {
      this.prodForm = this.fb.group({
        ProductName: ['', Validators.required],
        ProductDescription: ['', Validators.required],
        ProductRateId: ['', Validators.required],
        QuantityStock: ['', Validators.required]
      });
    } else {
      this.prodForm = this.fb.group({
        ProductName: ['', Validators.required],
        ProductDescription: ['', Validators.required],
        ProductRateId: ['', Validators.required],
        QuantityStock: ['', Validators.required],
      });
    }
  }
  cancelClick(): void {
    this.dialogRef.close();
  }

  submitForm(): void {
    this.dialogRef.close(this.product);
  }
}

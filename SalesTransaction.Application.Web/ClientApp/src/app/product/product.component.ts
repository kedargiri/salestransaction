import { NullTemplateVisitor } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { ProductService } from './product.services';
import { MvAddProduct } from './product.model';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { UtilityService } from 'src/core/Utility.Service';
import { ProductFormComponent } from './Product-form/Product-form.component';



@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  userMsg: string = null;
  displayColumns: string[];
  dataSource: MvAddProduct[] = [];
  selectedProduct: MvAddProduct = {} as MvAddProduct;
  selection = new SelectionModel<MvAddProduct>(false, []);


  constructor(
    private productService: ProductService,
    private dialog: MatDialog,
    private us: UtilityService
  ) { }

  ngOnInit(): void {
    this.displayColumns = ['productId', 'productName', 'productDescription', 'quantityStock'];
    this.getAllProducts();
  }

  getAllProducts(): void {
    this.productService.getAllProducts().subscribe(res => {
      if (res && res.data) {
        this.dataSource = res.data;
      } else {
        this.dataSource = [];
        this.userMsg = 'No data';
      }
    }, err => console.log(err));

  }

  addProduct(): void {
    this.selection.clear();
    this.selectedProduct = {} as MvAddProduct;
    this.openDialog('Add');
  }

  editProduct(): void {
    this.openDialog('Edit');
  }
  openDialog(action: string): void {
    if (action === 'Edit' && !this.selection.hasValue()) {
      this.us.openSnackBar('Select a product before editing', 'warning');
      return;
    }
    const dialogRef = this.dialog.open(ProductFormComponent, {
      data: {
        action,
        data: this.selectedProduct
      }

    });
    dialogRef.afterClosed().subscribe(product => {
      if (product) {
        if (action === 'Edit') {
          this.productService.updateProduct(product).subscribe(res => {
            this.getAllProducts();
            this.us.openSnackBar('Product Updated', 'success');
          });
        } else {
          this.productService.addProduct(product).subscribe(res => {
            this.getAllProducts();
            this.us.openSnackBar('Product Added', 'success');
          }, err => console.log(err));
        }
      }
    });
  }

  onRowClicked(row: any): void {
    this.selectedProduct = { ...row };
    this.selection.toggle(row);
  }
}

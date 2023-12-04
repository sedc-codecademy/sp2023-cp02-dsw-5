import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { WarningDialogComponent } from 'src/app/shared/components/warning-dialog/warning-dialog.component';
import Product, { ProductEdit } from 'src/app/shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  showEditDialog = false;
  public products$ = this.productService.productList$;
  public productToEdit: Product | null = null;

  constructor(private productService: ProductService, private dialog: MatDialog){}

  ngOnInit(): void {
    this.productService.GetProducts();
  }

  addBtnClick() {
    this.productToEdit = null;
    this.showEditDialog = true;
  }

  editBtnClick(id: number) {
    this.productToEdit = this.products$.value.find(x => x.id === id)?? null;
    this.showEditDialog = true;
  }

  editSubmit(productEdit: ProductEdit) {
    if(productEdit.id){
      this.productService.UpdateProduct(productEdit);
      this.productService.GetProducts();
    }
    else {
      this.productService.AddNewProduct(productEdit);
      this.productService.GetProducts();
    }
  }

  editDialogCancel() {
    this.showEditDialog = false;
  }

  deleteDialog(product: Product) {
    let ref = this.dialog.open(WarningDialogComponent, { data: `You are about to delete product [${product.name}]`});
    ref.afterClosed().subscribe(response => {
      if(!response) return;
      this.productService.deleteProduct(product.id);
      this.productService.GetProducts();
    })
  }
}

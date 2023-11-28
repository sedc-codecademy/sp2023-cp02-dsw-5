import { Component } from '@angular/core';
import Product, { ProductEdit } from 'src/app/shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  showEditDialog = false;
  public products: Product[] = [ new Product(1, "test", "Test", 12, 1) ];
  public productToEdit: Product | null = null;

  constructor(private productService: ProductService){}

  addBtnClick() {
    this.productToEdit = null;
    this.showEditDialog = true;
  }

  editBtnClick(id: number) {
    this.productToEdit = this.products.find(x => x.id === id)?? null;
    this.showEditDialog = true;
  }

  editSubmit(productEdit: ProductEdit) {
    if(productEdit.id){
      this.productService.UpdateProduct(productEdit);
    }
    else {
      this.productService.AddNewProduct(productEdit);
    }
  }

  editDialogCancel() {
    this.showEditDialog = false;
  }
}

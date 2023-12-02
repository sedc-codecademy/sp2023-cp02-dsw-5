import { Component, OnInit } from '@angular/core';
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

  constructor(private productService: ProductService){}

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
    }
    else {
      this.productService.AddNewProduct(productEdit);
    }
  }

  editDialogCancel() {
    this.showEditDialog = false;
  }
}

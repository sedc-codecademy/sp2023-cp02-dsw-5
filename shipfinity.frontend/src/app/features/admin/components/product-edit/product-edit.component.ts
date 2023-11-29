import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Product, { ProductEdit } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  @Output() cancel = new EventEmitter<void>();
  @Output() submit = new EventEmitter<ProductEdit>();
  @Input() product: Product | null;
  productForm: FormGroup;

  ngOnInit(): void {
    this.productForm = new FormGroup({
      name: new FormControl(this.product?.name?? '', [Validators.required]),
      categoryId: new FormControl(this.product?.categoryId?? 0, [Validators.required]),
      price: new FormControl(this.product?.price?? 0, [Validators.required]),
      description: new FormControl(this.product?.description?? '')
    });
  }

  submitForm() {
    if (!this.productForm.valid) return;

    if(this.product){
      let prod: ProductEdit = {
        id: this.product.id,
        name: this.productForm.value.name,
        categoryId: this.productForm.value.categoryId,
        price: this.productForm.value.price,
        description: this.productForm.value.description
      }
      this.submit.emit(prod);
      this.cancel.emit();
    }
    else {
      let prod: ProductEdit = {
        name: this.productForm.value.name,
        categoryId: this.productForm.value.categoryId,
        price: this.productForm.value.price,
        description: this.productForm.value.description
      }
      this.submit.emit(prod);
      this.cancel.emit();
    }
  }
}

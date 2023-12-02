import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { CategoryModel } from 'src/app/shared/models/category';
import Product, { ProductEdit } from 'src/app/shared/models/product';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit, OnDestroy {
  @Output() cancel = new EventEmitter<void>();
  @Output() submit = new EventEmitter<ProductEdit>();
  @Input() product: Product | null;
  productForm: FormGroup;
  categories: CategoryModel[] = [];
  private sub: Subscription;
  
  constructor(private categoryService: CategoryService){}
  ngOnInit(): void {
    this.productForm = new FormGroup({
      name: new FormControl(this.product?.name?? '', [Validators.required]),
      categoryId: new FormControl(this.product?.categoryId?? 0, [Validators.required]),
      price: new FormControl(this.product?.price?? 0, [Validators.required]),
      description: new FormControl(this.product?.description?? '')
    });
    this.sub = this.categoryService.categoryList$.subscribe(data => {
      this.categories = [...data];
      this.productForm.controls['categoryId'].setValue(this.product?.categoryId?? 1);
    })
    this.categoryService.getCategories();
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
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

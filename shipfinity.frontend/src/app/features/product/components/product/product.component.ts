import { ShoppingCartService } from './../../../../shared/services/shopping-cart.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Product from 'src/app/shared/models/product';
import ProductOrder from 'src/app/shared/models/product-order';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { ProductService } from 'src/app/shared/services/product.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  productDetails$ = this.productService.productDetails$;

  selectedRating: number = 0;
  comment: string = '';
  productId: number = 0;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private shoppingCartService: ShoppingCartService,
    private notificationService: NotificationService,
    private location: Location
  ) {}
  ngOnInit(): void {
    // const comment: string = '';
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));

    this.productService.GetByProductId(idFromRoute);
  }

  addToCartClick() {
    const product = this.productDetails$.value as Product;
    this.shoppingCartService.addItem(new ProductOrder(product, 1));
    this.notificationService.successMessage(`${product.name} added to cart`);
  }

  rateProduct(rating: number) {
    this.selectedRating = rating;
  }

  submitReview() {
    const productId = this.productDetails$.value?.id || 0;

    if (productId !== 0 && this.selectedRating !== 0) {
      this.productService.submitReview(
        productId,
        this.comment,
        this.selectedRating
      );
      console.log(productId, this.comment, this.selectedRating);
      this.notificationService.successMessage('Review submitted successfully');
    } else {
      this.notificationService.errorMessage(
        'Please select a rating and write a comment before submitting.'
      );
    }
  }

  goBack(): void {
    this.location.back();
  }
}

import { ShoppingCartService } from './../../../../shared/services/shopping-cart.service';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Product from 'src/app/shared/models/product';
import ProductOrder from 'src/app/shared/models/product-order';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  productDetails$ = this.productService.productDetails$;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private shoppingCartService: ShoppingCartService,
    private notificationService: NotificationService
  ) {}
  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const idFromRoute = Number(routeParams.get('id'));

    this.productService.GetByProductId(idFromRoute);
    console.log(this.productDetails$);
  }

  addToCartClick() {
    const product = this.productDetails$.value as Product;
    this.shoppingCartService.addItem(new ProductOrder(product, 1));
    this.notificationService.successMessage(`${product.name} added to cart`);
    console.log(product);
  }
}

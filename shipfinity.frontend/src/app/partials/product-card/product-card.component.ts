import { Component, Input } from '@angular/core';
import Product from 'src/app/shared/models/product';
import ProductOrder from 'src/app/shared/models/product-order';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { ShoppingCartService } from 'src/app/shared/services/shopping-cart.service';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent {
  @Input() product: Product = new Product();

  constructor(private shoppingCartService: ShoppingCartService, private notificationService: NotificationService){}

  addToCartClick() {
    this.shoppingCartService.addItem(new ProductOrder(this.product, 1));
    this.notificationService.successMessage(`${this.product.name} added to cart`);
  }
}

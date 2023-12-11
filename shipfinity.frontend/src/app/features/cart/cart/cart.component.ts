import { Component } from '@angular/core';
import { ShoppingCartService } from '../../../shared/services/shopping-cart.service';
import ProductOrder from '../../../shared/models/product-order';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  shoppingCartItems: ProductOrder[] = [];
  totalPrice: number = 0;
  productDetails$ = this.productService.productDetails$;

  constructor(
    private shoppingCartService: ShoppingCartService,
    private productService: ProductService
  ) {}

  ngOnInit() {
    this.shoppingCartService.getCart().subscribe((data) => {
      this.shoppingCartItems = data;
      this.calculateTotalPrice();
    });
  }

  changeQuantity(event: any, item: ProductOrder) {
    this.shoppingCartService.updateQuantity(item, event.target.value);
    this.calculateTotalPrice();
  }

  removeItem(item: ProductOrder) {
    this.shoppingCartService.removeItem(item);
    this.calculateTotalPrice();
  }

  calculateTotalPrice() {
    let total = 0;

    this.shoppingCartItems.forEach((item) => {
      if (item.product.discountPercentage > 0) {
        total +=
          (item.product.price -
            (item.product.price * item.product.discountPercentage) / 100) *
          item.quantity;
      } else {
        total += item.product.price * item.quantity;
      }
    });

    this.totalPrice = total;
  }
}

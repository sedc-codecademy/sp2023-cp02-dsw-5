import { Component } from '@angular/core';
import ProductOrder from '../shared/models/product-order';
import { ShoppingCartService } from '../shared/services/shopping-cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  cartItems: ProductOrder[];

  constructor(private shoppingCartService: ShoppingCartService){}

  ngOnInit(){
    this.shoppingCartService.getCart().subscribe(data => {
      this.cartItems = data;
    })
  }

  calculateTotal(){
    let total = 0;
    this.cartItems.forEach(item => {
      total += item.product.price * item.quantity;
    });
    return total;
  }

  paymentFormSubmitted(){
    
  }
}

import { Component } from '@angular/core';
import Product from '../shared/models/product';
import { ShoppingCartService } from '../shared/services/shopping-cart.service';
import ProductOrder from '../shared/models/product-order';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  shoppingCartItems: ProductOrder[] = [];
  totalPrice: number = 0;

  constructor(private shoppingCartService: ShoppingCartService){}

  ngOnInit(){
    this.shoppingCartService.getCart().subscribe(data => {
      this.shoppingCartItems = data;
      this.calculateTotalPrice();
    });
  }

  changeQuantity(event:any ,item: ProductOrder){
    // let itemIndex = this.shoppingCartItems.indexOf(item);
    // if(itemIndex === -1){
    //   return;
    // }
    // this.shoppingCartItems[itemIndex].setQuantity(event.target.value);
    this.shoppingCartService.updateQuantity(item, event.target.value);
    this.calculateTotalPrice();
  }

  removeItem(item: ProductOrder){
    this.shoppingCartService.removeItem(item);
    this.calculateTotalPrice();
  }

  calculateTotalPrice(){
    let total = 0;
    this.shoppingCartItems.forEach(item => {
      total += item.product.price * item.quantity;
    });
    this.totalPrice = total;
  }
}

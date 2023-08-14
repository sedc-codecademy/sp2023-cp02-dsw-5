import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import ProductOrder from '../models/product-order';
import Product from '../models/product';
@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private shoppingCart: ProductOrder[] = [new ProductOrder(new Product(), 1)];
  private cartSubject = new BehaviorSubject<ProductOrder[]>(this.shoppingCart);
  constructor() { }

  getCart() {
    return this.cartSubject.asObservable();
  }

  setCart(cart: ProductOrder[]){
    this.shoppingCart = cart;
    this.cartSubject.next(this.shoppingCart);
  }

  addItem(newItem: ProductOrder) {
    this.shoppingCart.push(newItem);
    localStorage.setItem("shopping-cart", JSON.stringify(this.shoppingCart));
    this.cartSubject.next(this.shoppingCart);
  }

  updateQuantity(item: ProductOrder, q: number){
    const index = this.shoppingCart.indexOf(item);
    if(index !== -1){
      this.shoppingCart[index].setQuantity(q);
    }
    localStorage.setItem("shopping-cart", JSON.stringify(this.shoppingCart));
  }
  
  removeItem(item: ProductOrder){
    const index = this.shoppingCart.indexOf(item);
    if(index !== -1){
      this.shoppingCart.splice(index, 1);
      localStorage.setItem("shopping-cart", JSON.stringify(this.shoppingCart));
      this.cartSubject.next(this.shoppingCart);
    }
  }
}

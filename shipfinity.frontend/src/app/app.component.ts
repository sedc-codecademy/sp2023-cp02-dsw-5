import { Component } from '@angular/core';
import { NotificationService } from './shared/services/notification.service';
import { tap } from 'rxjs';
import { ShoppingCartService } from './shared/services/shopping-cart.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'shipfinity.frontend';
  constructor(private shoppingCartService: ShoppingCartService){}

  ngOnInit(){
    let cart = localStorage.getItem("shopping-cart");
    if(cart){
      this.shoppingCartService.setCart(JSON.parse(cart));
    }
  }
}

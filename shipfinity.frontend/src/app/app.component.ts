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
  successNotification$ = this.notificationService.successMessageAction$.pipe(tap(message => {
    setTimeout(() =>{
      this.notificationService.clearMessages();
    }, 5000);
  }));
  errorNotification$ = this.notificationService.errorMessageAction$.pipe(tap(message => {
    setTimeout(() =>{
      this.notificationService.clearMessages();
    }, 5000);
  }));

  constructor(private notificationService: NotificationService, private shoppingCartService: ShoppingCartService){}

  ngOnInit(){
    let cart = localStorage.getItem("shopping-cart");
    if(cart){
      this.shoppingCartService.setCart(JSON.parse(cart));
    }
  }
}

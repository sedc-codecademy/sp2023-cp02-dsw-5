import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { cartRoutes } from './cart.routes';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';



@NgModule({
  declarations: [CartComponent, CheckoutComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(cartRoutes)
  ]
})
export class CartModule { }

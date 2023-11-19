import { Routes } from "@angular/router";
import { CartComponent } from "./cart/cart.component";
import { CheckoutComponent } from "./checkout/checkout.component";

export const cartRoutes: Routes = [
    { path: '', children: [
        { path: '', component: CartComponent },
        { path: 'checkout', component: CheckoutComponent }
    ] }
]
import { Component, OnDestroy, OnInit } from '@angular/core';
import ProductOrder from '../../../shared/models/product-order';
import { ShoppingCartService } from '../../../shared/services/shopping-cart.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { OrderService } from 'src/app/shared/services/order.service';
import IOrder from 'src/app/shared/models/order';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit, OnDestroy {
  cartItems: ProductOrder[];
  orderForm: FormGroup;
  private shoppingCartSub: Subscription;
  constructor(
    private shoppingCartService: ShoppingCartService,
    private orderService: OrderService
  ) {}

  ngOnInit() {
    this.orderForm = new FormGroup({
      fullName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      addressLine: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),
      country: new FormControl('', [Validators.required]),
      zipCode: new FormControl(0, [Validators.required]),
      cardHolderName: new FormControl('', [Validators.required]),
      cardNumber: new FormControl('', [Validators.required]),
      expiryMonth: new FormControl(1, [Validators.required]),
      expiryYear: new FormControl(new Date().getFullYear(), [
        Validators.required,
      ]),
      cvv: new FormControl(123, [Validators.required]),
    });

    this.shoppingCartSub = this.shoppingCartService
      .getCart()
      .subscribe((data) => {
        this.cartItems = data;
      });
  }

  ngOnDestroy(): void {
    if (this.shoppingCartSub) this.shoppingCartSub.unsubscribe();
  }

  calculateTotal() {
    let total = 0;
    this.cartItems.forEach((item) => {
      if (item.product.discountPercentage > 0) {
        total +=
          (item.product.price -
            (item.product.price * item.product.discountPercentage) / 100) *
          item.quantity;
      } else {
        total += item.product.price * item.quantity;
      }
    });
    return total;
  }

  paymentFormSubmitted() {
    const order: IOrder = {
      email: this.orderForm.value.email,
      address: {
        addressLine: this.orderForm.value.addressLine,
        city: this.orderForm.value.city,
        country: this.orderForm.value.country,
        zipCode: this.orderForm.value.zipCode,
      },
      paymentInfo: {
        cardHolderName: this.orderForm.value.cardHolderName,
        cardNumber: this.orderForm.value.cardNumber,
        expiryMonth: this.orderForm.value.expiryMonth,
        expiryYear: this.orderForm.value.expiryYear,
        CVV: this.orderForm.value.cvv,
      },
      orderDetails: this.cartItems.map((item) => {
        return { productId: item.product.id, quantity: item.quantity };
      }),
    };
    this.orderService.makeOrder(order).subscribe({
      next: (_) => {
        this.orderForm.reset();
        this.shoppingCartService.setCart([]);
      },
    });
  }
}

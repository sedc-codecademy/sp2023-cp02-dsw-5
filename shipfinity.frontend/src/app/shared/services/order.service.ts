import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import IOrder from '../models/order';
import { tap } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = `${environment.API_URL}/order`;
  constructor(private http: HttpClient, private notification: NotificationService) { }

  public makeOrder(order: IOrder){
    return this.http.post(this.ordersUrl, order).pipe(tap({
      next: _ => this.notification.successMessage("Order created"),
      error: err => this.notification.errorMessage("Error processing order")
    }))
  }
}

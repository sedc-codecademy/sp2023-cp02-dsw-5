import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import IOrder, { IOrderSellerDetails, IOrderSellerList } from '../models/order';
import { BehaviorSubject, map, tap } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = `${environment.API_URL}/order`;
  sellerProducts$ = new BehaviorSubject<IOrderSellerList[]>([]);
  constructor(private http: HttpClient, private notification: NotificationService) { }

  public makeOrder(order: IOrder){
    return this.http.post(this.ordersUrl, order).pipe(tap({
      next: _ => this.notification.successMessage("Order created"),
      error: err => this.notification.errorMessage("Error processing order")
    }))
  }

  public getBySeller(){
    this.http.get(`${this.ordersUrl}/seller`).pipe(map(data => data as IOrderSellerList[])).subscribe({
      next: data => this.sellerProducts$.next([...data]),
      error: err => this.notification.errorMessage("Error getting orders")
    });
  }

  public getOrderDetails(id: number){
    return this.http.get(`${this.ordersUrl}/${id}`).pipe(map(data => data as IOrderSellerDetails));
  }

  public shipOrder(id: number){
    return this.http.post(`${this.ordersUrl}/ship`, {orderId: id});
  }
}

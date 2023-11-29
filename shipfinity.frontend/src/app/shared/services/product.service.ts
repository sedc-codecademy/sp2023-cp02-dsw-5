import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import Product, { ProductEdit } from '../models/product';
import { environment } from 'src/environments/environment';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public productList$ = new BehaviorSubject<Product[]>([]);
  constructor(private http: HttpClient, public notifications: NotificationService) {}

  public GetProducts() {
    this.http.get(`${environment.API_URL}/products`)
    .pipe(map(data => data as Product[]))
    .subscribe({
      next: data => {
        this.productList$.next([...data]);
      },
      error: err => {
        this.notifications.errorMessage(err.message);
      }
    });
  }

  public AddNewProduct(product: ProductEdit) {
    this.http.post(`${environment.API_URL}/products`, product)
    .subscribe({
      next: data => {
        this.notifications.successMessage("Product saved");
    },
      error: err => {
        this.notifications.errorMessage("Error while saving");
    }});
  }

  public UpdateProduct(product: ProductEdit) {
    this.http.put(`${environment.API_URL}/products/${product.id}`, product)
    .subscribe({
      next: data => {
        this.notifications.successMessage("Product saved");
    },
      error: err => {
        this.notifications.errorMessage("Error while saving");
    }});
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import Product, { ProductEdit } from '../models/product';
import { environment } from 'src/environments/environment';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  public productList$ = new BehaviorSubject<Product[]>([]);
  public productDetails$ = new BehaviorSubject<Product>(new Product());

  constructor(
    private http: HttpClient,
    public notifications: NotificationService
  ) {}

  public GetProducts() {
    this.http
      .get(`${environment.API_URL}/product`)
      .pipe(map((data) => data as Product[]))
      .subscribe({
        next: (data) => {
          this.productList$.next([...data]);
        },
        error: (err) => {
          this.notifications.errorMessage(err.message);
        },
      });
  }

  public GetByCategory(id: number) {
    this.http
      .get(`${environment.API_URL}/product/byCategory/${id}`)
      .pipe(map((data) => data as Product[]))
      .subscribe({
        next: (data) => {
          this.productList$.next([...data]);
        },
        error: (err) => {
          this.notifications.errorMessage(err.message);
        },
      });
  }

  public AddNewProduct(product: ProductEdit) {
    delete product.id;
    this.http.post(`${environment.API_URL}/product`, product).subscribe({
      next: (data) => {
        this.notifications.successMessage('Product saved');
      },
      error: (err) => {
        console.log(err);
        this.notifications.errorMessage('Error while saving');
      },
    });
  }

  public deleteProduct(id: number){
    this.http.delete(`${environment.API_URL}/product/${id}`)
    .subscribe({
      next: data => {
        this.notifications.successMessage("Product deleted");
      },
      error: err => {
        this.notifications.errorMessage("Error while deleting");
      }
    })
  }

  public UpdateProduct(product: ProductEdit) {
    this.http
      .put(`${environment.API_URL}/product/${product.id}`, product)
      .subscribe({
        next: (data) => {
          this.notifications.successMessage('Product saved');
        },
        error: (err) => {
          this.notifications.errorMessage('Error while saving');
        },
      });
  }

  public GetByProductId(id: number) {
    this.http
      .get(`${environment.API_URL}/product/${id}`)
      .pipe(map((data) => data as Product))
      .subscribe({
        next: (data) => {
          this.productDetails$.next(data);
        },
        error: (err) => {
          this.notifications.errorMessage(err.message);
        },
      });
  }

  uploadImage(id: number, blob: File){
    const data = new FormData();
    data.append('file', blob, blob.name);
    return this.http.post(`${environment.API_URL}/product/${id}/UploadPhoto`, data)
    .subscribe({
      next: _ => this.notifications.successMessage("Uploaded photo"),
      error: err => this.notifications.errorMessage("Error while upload")
    });
  }
}

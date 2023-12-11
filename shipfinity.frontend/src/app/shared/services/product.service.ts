import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import Product, { ProductDetails, ProductEdit } from '../models/product';
import { environment } from 'src/environments/environment';
import { NotificationService } from './notification.service';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  public productList$ = new BehaviorSubject<Product[]>([]);
  public productDetails$ = new BehaviorSubject<ProductDetails | null>(null);
  public saleProducts$ = new BehaviorSubject<Product[]>([]);

  constructor(
    private http: HttpClient,
    public notifications: NotificationService,
    private authService: AuthService
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
        this.notifications.errorMessage('Error while saving');
      },
    });
  }

  public deleteProduct(id: number) {
    this.http.delete(`${environment.API_URL}/product/${id}`).subscribe({
      next: (data) => {
        this.notifications.successMessage('Product deleted');
      },
      error: (err) => {
        this.notifications.errorMessage('Error while deleting');
      },
    });
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
      .pipe(map((data) => data as ProductDetails))
      .subscribe({
        next: (data) => {
          this.productDetails$.next(data);
        },
        error: (err) => {
          this.notifications.errorMessage(err.message);
        },
      });
  }

  uploadImage(id: number, blob: File) {
    const data = new FormData();
    data.append('file', blob, blob.name);
    return this.http
      .post(`${environment.API_URL}/product/${id}/UploadPhoto`, data)
      .subscribe({
        next: (_) => this.notifications.successMessage('Uploaded photo'),
        error: (err) => this.notifications.errorMessage('Error while upload'),
      });
  }

  public submitReview(productId: number, comment: string, rating: number) {
    const reviewData = {
      comment: comment,
      rating: rating,
      customerId: this.authService.currentUser$.value?.id,
    };

    const token = this.authService.getToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer' + token,
    });

    this.http
      .post(`${environment.API_URL}/product/${productId}/reviews`, reviewData, {
        headers: headers,
      })
      .subscribe(
        (data) => {
          this.notifications.successMessage('Review submitted successfully');
        },
        (err) => {
          this.notifications.errorMessage('Failed to submit review');
        }
      );
  }

  public getProductsOnSale() {
    this.http
      .get(`${environment.API_URL}/product/OnSale`)
      .pipe(map((data) => data as Product[]))
      .subscribe({
        next: (data) => {
          this.saleProducts$.next([...data]);
        },
        error: (err) => {
          console.error(err);
        },
      });
  }
}

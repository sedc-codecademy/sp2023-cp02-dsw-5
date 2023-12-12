import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import Product from '../models/product';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private apiUrl = `${environment.API_URL}/products/search`;

  constructor(private http: HttpClient) {}

  searchProducts(keyword: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}?search=${keyword}`);
  }
}

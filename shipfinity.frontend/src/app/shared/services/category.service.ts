import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { CategoryModel } from '../models/category';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  categoryList$ = new BehaviorSubject<CategoryModel[]>([]);
  currentCategory$ = new BehaviorSubject<CategoryModel>({id:0,name:"", displayName:""});
  constructor(private http: HttpClient) { }

  getCategories() {
    this.http.get(`${environment.API_URL}/category`).pipe(map(data => data as CategoryModel[]))
    .subscribe({
      next: data => {
        this.categoryList$.next([...data]);
      }
    })
  }

  getById(id: number) {
    this.http.get(`${environment.API_URL}/category/${id}`).pipe(map(data => data as CategoryModel))
    .subscribe({
      next: data => {
        this.currentCategory$.next(data);
      }
    })
  }
}

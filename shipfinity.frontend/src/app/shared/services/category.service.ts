import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { CategoryCreateModel, CategoryModel } from '../models/category';
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
    });
  }

  getById(id: number) {
    this.http.get(`${environment.API_URL}/category/${id}`).pipe(map(data => data as CategoryModel))
    .subscribe({
      next: data => {
        this.currentCategory$.next(data);
      }
    });
  }

  createCategory(cat: CategoryCreateModel){
    return this.http.post(`${environment.API_URL}/category`, cat);
  }

  editCategory(cat: CategoryCreateModel){
    return this.http.put(`${environment.API_URL}/category/${cat.id}`, cat);
  }

  deleteCategory(id: number){
    return this.http.delete(`${environment.API_URL}/category/${id}`);
  }
}

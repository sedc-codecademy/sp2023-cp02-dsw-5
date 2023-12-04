import { Component, OnInit } from '@angular/core';
import { CategoryModel } from 'src/app/shared/models/category';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories$ = this.categoryService.categoryList$;

  constructor(private categoryService: CategoryService){}

  ngOnInit(): void {
    this.categoryService.getCategories();
  }
}

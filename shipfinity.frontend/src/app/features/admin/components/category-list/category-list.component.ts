import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CategoryModel } from 'src/app/shared/models/category';
import { CategoryService } from 'src/app/shared/services/category.service';
import { CategoryEditDialogComponent } from '../category-edit-dialog/category-edit-dialog.component';
import { WarningDialogComponent } from 'src/app/shared/components/warning-dialog/warning-dialog.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories$ = this.categoryService.categoryList$;

  constructor(private categoryService: CategoryService, private dialog: MatDialog){}

  ngOnInit(): void {
    this.categoryService.getCategories();
  }

  createNew() {
    let ref = this.dialog.open(CategoryEditDialogComponent);
    ref.afterClosed().subscribe(data => {
      if (data === null) return;
      this.categoryService.createCategory(data).subscribe({
        next: _ => this.categoryService.getCategories()
      })
    });
  }

  editCategory(cat: CategoryModel){
    let ref = this.dialog.open(CategoryEditDialogComponent, {data: cat});
    ref.afterClosed().subscribe(data => {
      if(data === null) return;
      this.categoryService.editCategory(cat).subscribe({
        next: _ => this.categoryService.getCategories()
      });
    });
  }

  deleteCategory(cat: CategoryModel){
    let ref = this.dialog.open(WarningDialogComponent, {data:`You are about to delete category [${cat.name}]`});
    ref.afterClosed().subscribe(response => {
      if(!response) return;
      this.categoryService.deleteCategory(cat.id).subscribe({
        next: _ => this.categoryService.getCategories()
      })
    });
  }
}

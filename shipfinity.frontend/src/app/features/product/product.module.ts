import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './components/product/product.component';
import { CategoryComponent } from './components/category/category.component';
import { ProductCardComponent } from 'src/app/partials/product-card/product-card.component';
import { SearchComponent } from './components/search/search.component';
import { SaleComponent } from './components/sale/sale.component';
import { RouterModule } from '@angular/router';
import { productRoutes } from './product.routes';



@NgModule({
  declarations: [ProductComponent, CategoryComponent, ProductCardComponent, SearchComponent, SaleComponent ],
  imports: [
    CommonModule,
    RouterModule.forChild(productRoutes)
  ]
})
export class ProductModule { }

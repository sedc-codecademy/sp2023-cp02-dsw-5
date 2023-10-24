import { Routes } from "@angular/router";
import { CategoryComponent } from "./components/category/category.component";
import { SearchComponent } from "./components/search/search.component";
import { ProductComponent } from "./components/product/product.component";
import { SaleComponent } from "./components/sale/sale.component";

export const productRoutes: Routes = [
    { path: '', children: [
        { path: 'category/:id', component: CategoryComponent },
        { path: 'search', component: SearchComponent },
        { path: 'sale', component: SaleComponent },
        { path: ':id', component: ProductComponent }
    ] }
]
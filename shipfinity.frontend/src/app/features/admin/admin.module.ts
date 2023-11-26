import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductEditComponent } from './components/product-edit/product-edit.component';
import { AdminLoginComponent } from './components/admin-login/admin-login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderListComponent } from './components/order-list/order-list.component';
import { OrderManageComponent } from './components/order-manage/order-manage.component';
import { CategoryListComponent } from './components/category-list/category-list.component';

const routes: Routes = [
  { path: 'login', component: AdminLoginComponent },
  { path: '', component: AdminLayoutComponent, children: [
    { path: 'products', component: ProductListComponent },
    { path: 'categories', component: CategoryListComponent },
    { path: 'orders', component: OrderListComponent }
  ] }
]

@NgModule({
  declarations: [
    AdminLayoutComponent,
    ProductListComponent,
    ProductEditComponent,
    AdminLoginComponent,
    OrderListComponent,
    OrderManageComponent,
    CategoryListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    FormsModule
  ]
})
export class AdminModule { }

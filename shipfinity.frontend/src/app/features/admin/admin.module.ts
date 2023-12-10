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
import { SharedModule } from 'src/app/shared/shared.module';
import { MessageListComponent } from './components/message-list/message-list.component';
import { MessageDetailsComponent } from './components/message-details/message-details.component';
import { sellerGuard } from 'src/app/shared/guards/seller.guard';
import { CategoryEditDialogComponent } from './components/category-edit-dialog/category-edit-dialog.component';
import { AdminSellerRegisterComponent } from './components/admin-seller-register/admin-seller-register.component';

const routes: Routes = [
  { path: 'login', component: AdminLoginComponent },
  { path: '', component: AdminLayoutComponent, children: [
    { path: 'categories', component: CategoryListComponent, canActivate: [sellerGuard] },
    { path: 'products', component: ProductListComponent, canActivate: [sellerGuard] },
    { path: 'messages', component: MessageListComponent, canActivate: [sellerGuard] },
    { path: 'orders', component: OrderListComponent, canActivate: [sellerGuard] }
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
    CategoryListComponent,
    MessageListComponent,
    MessageDetailsComponent,
    CategoryEditDialogComponent,
    AdminSellerRegisterComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ]
})
export class AdminModule { }

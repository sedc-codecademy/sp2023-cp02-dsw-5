import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { ContactComponent } from './core/components/contact/contact.component';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { anonymousGuard } from './shared/guards/anonymous.guard';
import { sellerGuard } from './shared/guards/seller.guard';

const routes: Routes = [
  { path: 'contact', component: ContactComponent },
  { path: 'login', component: LoginComponent, canActivate: [anonymousGuard] },
  { path: 'signup', component: RegisterComponent, canActivate: [anonymousGuard] },
  { path: 'admin', loadChildren: () => import('./features/admin/admin.module').then(m => m.AdminModule) },
  { path: 'cart', loadChildren: () => import('./features/cart/cart.module').then(m => m.CartModule) },
  { path: 'product', loadChildren: () => import('./features/product/product.module').then(m => m.ProductModule) },
  { path: '', component: HomeComponent },

  // Wildcard
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent, runGuardsAndResolvers: 'always' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }

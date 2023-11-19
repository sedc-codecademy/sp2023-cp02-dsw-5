import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { ContactComponent } from './core/components/contact/contact.component';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'cart', loadChildren: () => import('./features/cart/cart.module').then(m => m.CartModule) },
  { path: 'product', loadChildren: () => import('./features/product/product.module').then(m => m.ProductModule) },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegisterComponent },

  // Wildcard
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent, runGuardsAndResolvers: 'always' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }

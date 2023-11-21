import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';



@NgModule({
  declarations: [HomeComponent, PageNotFoundComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [HomeComponent, PageNotFoundComponent]
})
export class CoreModule { }

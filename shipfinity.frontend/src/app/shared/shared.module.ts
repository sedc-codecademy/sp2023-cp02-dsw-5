import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { FlyoutComponent } from './components/flyout/flyout.component';
import { LoaderComponent } from './components/loader/loader.component';



@NgModule({
  declarations: [
    FlyoutComponent,
    LoaderComponent,
  ],
  imports: [
    CommonModule,
    MatDialogModule
  ],
  exports: [
    FlyoutComponent,
    LoaderComponent,
    MatDialogModule
  ]
})
export class SharedModule { }

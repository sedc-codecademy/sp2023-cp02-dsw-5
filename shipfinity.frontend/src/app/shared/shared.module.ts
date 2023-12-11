import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { FlyoutComponent } from './components/flyout/flyout.component';
import { LoaderComponent } from './components/loader/loader.component';
import { WarningDialogComponent } from './components/warning-dialog/warning-dialog.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    FlyoutComponent,
    LoaderComponent,
    WarningDialogComponent,
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    ReactiveFormsModule
  ],
  exports: [
    FlyoutComponent,
    LoaderComponent,
    MatDialogModule,
    ReactiveFormsModule,
    WarningDialogComponent
  ]
})
export class SharedModule { }

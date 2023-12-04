import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { FlyoutComponent } from './components/flyout/flyout.component';
import { LoaderComponent } from './components/loader/loader.component';
import { WarningDialogComponent } from './components/warning-dialog/warning-dialog.component';



@NgModule({
  declarations: [
    FlyoutComponent,
    LoaderComponent,
    WarningDialogComponent,
  ],
  imports: [
    CommonModule,
    MatDialogModule
  ],
  exports: [
    FlyoutComponent,
    LoaderComponent,
    MatDialogModule,
    WarningDialogComponent
  ]
})
export class SharedModule { }

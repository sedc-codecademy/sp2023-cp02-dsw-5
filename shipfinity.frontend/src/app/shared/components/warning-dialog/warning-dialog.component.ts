import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-warning-dialog',
  templateUrl: './warning-dialog.component.html',
  styleUrls: ['./warning-dialog.component.css']
})
export class WarningDialogComponent implements OnInit {
  message: string;

  constructor(private dialogRef: MatDialogRef<WarningDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: string){}
  ngOnInit(): void {
    this.message = this.data;
  }

  cancel() {
    this.dialogRef.close(false);
  }

  continue(){
    this.dialogRef.close(true);
  }
}

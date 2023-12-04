import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CategoryCreateModel, CategoryModel } from 'src/app/shared/models/category';

@Component({
  selector: 'app-category-edit-dialog',
  templateUrl: './category-edit-dialog.component.html',
  styleUrls: ['./category-edit-dialog.component.css']
})
export class CategoryEditDialogComponent implements OnInit {
  editForm: FormGroup;
  isCreate: boolean = false;
  constructor(private dialogRef: MatDialogRef<CategoryEditDialogComponent>, @Inject(MAT_DIALOG_DATA) public data?: CategoryModel){}

  ngOnInit(): void {
    this.editForm = new FormGroup({
      name: new FormControl(this.data?.name?? '', [Validators.required]),
      displayName: new FormControl(this.data?.displayName?? '', [Validators.required])
    });
    this.isCreate = !this.data ? true : false;
  }

  cancel() {
    this.dialogRef.close(null);
  }

  submit() {
    if(this.editForm.invalid) return;
    let request : CategoryCreateModel = {
      name: this.editForm.value.name,
      displayName: this.editForm.value.displayName
    };
    if(!!this.data) request.id = this.data.id;
    this.dialogRef.close(request);
  }
}

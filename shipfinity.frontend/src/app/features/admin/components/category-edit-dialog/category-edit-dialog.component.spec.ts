import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryEditDialogComponent } from './category-edit-dialog.component';

describe('CategoryEditDialogComponent', () => {
  let component: CategoryEditDialogComponent;
  let fixture: ComponentFixture<CategoryEditDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoryEditDialogComponent]
    });
    fixture = TestBed.createComponent(CategoryEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

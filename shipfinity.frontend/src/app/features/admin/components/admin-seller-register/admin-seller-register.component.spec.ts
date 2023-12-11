import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminSellerRegisterComponent } from './admin-seller-register.component';

describe('AdminSellerRegisterComponent', () => {
  let component: AdminSellerRegisterComponent;
  let fixture: ComponentFixture<AdminSellerRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminSellerRegisterComponent]
    });
    fixture = TestBed.createComponent(AdminSellerRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

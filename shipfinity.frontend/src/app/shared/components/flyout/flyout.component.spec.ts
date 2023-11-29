import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlyoutComponent } from './flyout.component';

describe('FlyoutComponent', () => {
  let component: FlyoutComponent;
  let fixture: ComponentFixture<FlyoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FlyoutComponent]
    });
    fixture = TestBed.createComponent(FlyoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

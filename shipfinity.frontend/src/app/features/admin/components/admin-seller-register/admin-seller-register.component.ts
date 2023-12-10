import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  ValidatorFn,
} from '@angular/forms';
import { IRegisterSeller } from 'src/app/shared/models/register-seller-form-data';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-admin-seller-register',
  templateUrl: './admin-seller-register.component.html',
  styleUrls: ['./admin-seller-register.component.css'],
})
export class AdminSellerRegisterComponent implements OnInit {
  sellerRegisterForm: FormGroup;
  registerSuccessful: ((value: any) => void) | undefined;
  registerFailed: ((err: any) => void) | undefined;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.sellerRegisterForm = new FormGroup(
      {
        username: new FormControl('', [
          Validators.required,
          Validators.maxLength(50),
        ]),
        password: new FormControl('', [
          Validators.required,
          Validators.minLength(6),
        ]),
        confirmPassword: new FormControl('', [
          Validators.required,
          Validators.minLength(6),
        ]),
        email: new FormControl('', [
          Validators.required,
          Validators.email,
          Validators.maxLength(50),
        ]),
        phoneNumber: new FormControl('', [
          Validators.required,
          Validators.maxLength(20),
        ]),
        address: new FormControl('', [
          Validators.required,
          Validators.maxLength(50),
        ]),
        name: new FormControl('', [
          Validators.required,
          Validators.maxLength(30),
        ]),
      },
      { validators: this.passwordMatchValidator as ValidatorFn }
    );
  }

  passwordMatchValidator(form: FormGroup): { [key: string]: boolean } | null {
    const password = form.get('password');
    const confirmPassword = form.get('confirmPassword');
    return password &&
      confirmPassword &&
      password.value === confirmPassword.value
      ? null
      : { mismatch: true };
  }

  onSubmit(): void {
    if (this.sellerRegisterForm.valid) {
      const sellerData = this.prepareSellerData();
      this.authService.registerSeller(sellerData).subscribe({
        next: this.registerSuccessful,
        error: this.registerFailed,
      });
    } else {
      console.error('Form is not valid');
    }
  }
  private prepareSellerData(): IRegisterSeller {
    const formValues = this.sellerRegisterForm.value;
    return {
      username: formValues.username,
      password: formValues.password,
      confirmPassword: formValues.confirmPassword, // Add confirmPassword property
      email: formValues.email,
      phoneNumber: formValues.phoneNumber,
      address: formValues.address,
      name: formValues.name,
      // Note: confirmPassword is used only for validation and not sent to backend
    };
  }
}

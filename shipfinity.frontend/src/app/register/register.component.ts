import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { passwordConfirmValidator } from '../shared/validators/password-confirm.validator';
import { AuthService } from '../shared/services/auth.service';
import IRegisterFormModel from '../shared/models/register-form-data';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  registerForm = new FormGroup(
    {
      username: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(30),
      ]),
      firstName: new FormControl('', [
        Validators.required,
        Validators.maxLength(30),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.maxLength(30),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
      passwordRepeated: new FormControl('', [Validators.required]),
      email: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.maxLength(30),
      ]),
    },
    { validators: passwordConfirmValidator() }
  );
  usernameTaken: boolean = false;

  constructor(private auth: AuthService) {}

  onRegisterSubmit() {
    if (!this.registerForm.valid) {
      return;
    }
    this.auth
      .checkUsername(this.registerForm.value.username!)
      .subscribe({ next: this.usernameInvalid, error: this.usernameInvalid });
  }
  usernameInvalid = (error: any) => {
    this.usernameTaken = true;
    console.error(error);
  };

  registerSuccessful = (data: any) => {
    // Notify they've been registered or login
    console.log('Registration successful', data);
  };

  registerFailed = (error: any) => {
    console.error(error);
  };
}

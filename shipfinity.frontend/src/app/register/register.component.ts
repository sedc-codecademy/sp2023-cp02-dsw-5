import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { passwordConfirmValidator } from '../shared/validators/password-confirm.validator';
import { AuthService } from '../shared/services/auth.service';
import IRegisterFormModel from '../shared/models/register-form-data';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
    firstName: new FormControl('', [Validators.required, Validators.maxLength(30)]),
    lastName: new FormControl('', [Validators.required, Validators.maxLength(30)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    passwordRepeated: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(30)])
  }, { validators: passwordConfirmValidator() });
  usernameTaken: boolean = false;

  constructor(private auth: AuthService){}

  onRegisterSubmit() {
    if(!this.registerForm.valid){
      return;
    }
    this.auth.checkUsername(this.registerForm.value.username!).subscribe({next: this.usernameIsValid, error: this.usernameInvalid});
  }

  usernameIsValid = (data: any) => {
    this.usernameTaken = false;
    const formData : IRegisterFormModel = {
      username: this.registerForm.value.username!,
      firstName: this.registerForm.value.firstName!,
      lastName: this.registerForm.value.lastName!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
      confirmPassword: this.registerForm.value.passwordRepeated!
    }
    this.auth.register(formData).subscribe({next: this.registerSuccessful, error: this.registerFailed})
  }

  usernameInvalid = (error: any) => {
    this.usernameTaken = true;
    console.error(error);
  }

  registerSuccessful = (data: any) => {
    // Notify they've been registered or login
  }

  registerFailed = (error: any) => {
    console.error(error);
  }
}

import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm = new FormGroup({
    username: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    passwordRepeated: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(30)])
  });

  onRegisterSubmit() {
    
  }
}

import { Component } from '@angular/core';
import ILoginFormData from '../shared/models/login-form-data';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginFormData: ILoginFormData = {
    username: "",
    password: ""
  };

  submitLoginForm(){
    console.log(this.loginFormData);
  }
}

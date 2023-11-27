import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import IRegisterFormModel from '../../models/register-form-data';

const API_URL = environment.API_URL;

@Injectable({
  providedIn: 'root',
})
export class AuthApiService {
  private http = inject(HttpClient);

  loginUser(username: string, password: string) {
    return this.http.post(
      `${API_URL}/auth/customer/login`,
      { username, password },
      {
        observe: 'response',
      }
    );
  }

  registerUser(reqBody: IRegisterFormModel) {
    return this.http.post(`${API_URL}/auth/customer/register`, reqBody);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import ILoginFormData from '../models/login-form-data';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  get isLoggedIn() {
    return !!localStorage.getItem("Token");
  }

  public login(request: ILoginFormData) {
    return this.http.post(`${environment.API_URL}/auth/login`, request);
  }
}

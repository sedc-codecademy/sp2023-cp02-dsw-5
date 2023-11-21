import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import ILoginFormData from '../models/login-form-data';
import { environment } from 'src/environments/environment';
import IRegisterFormModel from '../models/register-form-data';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  get isLoggedIn() {
    return !!localStorage.getItem('Token');
  }

  public setToken(token: string) {
    localStorage.setItem('Token', token);
  }

  public getToken() {
    localStorage.getItem('Token');
  }

  public deleteToken() {
    localStorage.removeItem('Token');
  }

  public login(request: ILoginFormData) {
    return this.http.post(`${environment.API_URL}/auth/login`, request);
  }

  public register(requestData: IRegisterFormModel) {
    return this.http.post(`${environment.API_URL}/auth/register`, requestData);
  }

  public checkUsername(username: string) {
    return this.http.get(
      `${environment.API_URL}/auth/check?username=${username}`
    );
  }

  public saveUserInLocalStorage(user: IRegisterFormModel) {
    localStorage.setItem('User', JSON.stringify(user));
  }

  public getUserFromLocalStorage(): IRegisterFormModel | null {
    const stringUserData = localStorage.getItem('User');

    return stringUserData ? JSON.parse(stringUserData) : null;
  }
}

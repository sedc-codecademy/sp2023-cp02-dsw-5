import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import ILoginFormData from '../models/login-form-data';
import { environment } from 'src/environments/environment';
import IRegisterFormModel from '../models/register-form-data';
import { BehaviorSubject } from 'rxjs';
import { User } from '../models/user';
import { AuthApiService } from './api/auth-api.service';
import { Router } from '@angular/router';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private authApiService = inject(AuthApiService);
  private router = inject(Router);
  private notificationService = inject(NotificationService);

  public currentUser$ = new BehaviorSubject<User>(
    this.getUserFromLocalStorage()
  );

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

  /*
  public login(request: ILoginFormData) {
    return this.http.post(`${environment.API_URL}/auth/login`, request);
  }
  */

  public login(username: string, password: string) {
    this.authApiService.loginUser(username, password).subscribe({
      next: (res) => {
        console.log(res);

        const token = res.headers.get('access-token');
        console.log(token);

        const user = res.body as User;
        console.log(user);

        this.saveUserInLocalStorage(user);
        this.currentUser$.next(user);
        this.router.navigate(['home']);
        this.notificationService.successMessage('Successfully logged in!');
      },
      error: (error) => {
        console.log(error);
        this.notificationService.errorMessage(error.error.message);
      },
    });
  }

  public register(requestData: IRegisterFormModel) {
    return this.http.post(`${environment.API_URL}/auth/register`, requestData);
  }

  public checkUsername(username: string) {
    return this.http.get(
      `${environment.API_URL}/auth/check?username=${username}`
    );
  }

  saveUserInLocalStorage(user: User) {
    localStorage.setItem('currentUser', JSON.stringify(user));
  }

  getUserFromLocalStorage(): User {
    const stringUserData = localStorage.getItem('currentUser');

    return stringUserData ? JSON.parse(stringUserData) : null;
  }
}

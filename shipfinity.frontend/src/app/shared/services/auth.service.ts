import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import IRegisterFormModel from '../models/register-form-data';
import { BehaviorSubject, Observable, catchError, tap, throwError } from 'rxjs';
import { User } from '../models/user';
import { AuthApiService } from './api/auth-api.service';
import { Router } from '@angular/router';
import { NotificationService } from './notification.service';
import { IRegisterSeller } from '../models/register-seller-form-data';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private authApiService = inject(AuthApiService);
  private router = inject(Router);
  private notificationService = inject(NotificationService);

  public currentUser$ = new BehaviorSubject<User | null>(
    this.getUserFromLocalStorage()
  );

  constructor(private http: HttpClient) {}

  public registerSeller(requestData: IRegisterSeller): Observable<any> {
    return this.http
      .post(`${environment.API_URL}/seller/register`, requestData)
      .pipe(
        tap((res: any) => {
          // Assuming the response includes user data and a token
          this.setToken(res.token);
          this.saveUserInLocalStorage(res as User);
          this.currentUser$.next(res as User);
          this.notificationService.successMessage(
            'Seller registration successful!'
          );
        }),
        catchError((error) => {
          this.notificationService.errorMessage(
            error.error.message || 'Seller registration failed'
          );
          return throwError(error);
        })
      );
  }

  get isLoggedIn() {
    return !!localStorage.getItem('Token');
  }

  public setToken(token: string) {
    localStorage.setItem('Token', token);
  }

  public getToken() {
    return localStorage.getItem('Token');
  }

  public deleteToken() {
    localStorage.removeItem('Token');
  }

  public login(username: string, password: string) {
    this.authApiService.loginUser(username, password).subscribe({
      next: (res) => {
        const user = res as User;
        this.setToken(user.token);

        this.saveUserInLocalStorage(user);
        this.currentUser$.next(user);
        this.router.navigate(['/']);
        this.notificationService.successMessage('Successfully logged in!');
      },
      error: (error) => {
        this.notificationService.errorMessage(error.message);
      },
    });
  }

  public loginSeller(username: string, password: string) {
    this.authApiService.loginSeller(username, password).subscribe({
      next: (res) => {
        const user = res as User;
        this.setToken(user.token);

        this.saveUserInLocalStorage(user);
        this.currentUser$.next(user);
        this.router.navigate(['/admin/products']);
        this.notificationService.successMessage('Successfully logged in!');
      },
      error: (error) => {
        this.notificationService.errorMessage(error.message);
      },
    });
  }

  public register(requestData: IRegisterFormModel): Observable<any> {
    return this.authApiService.registerUser(requestData).pipe(
      tap((res) => {
        const user = res as User;
        this.setToken(user.token);
        this.saveUserInLocalStorage(user);
        this.currentUser$.next(user);

        this.notificationService.successMessage('Registration successful!');
        this.router.navigate(['/dashboard']);
      }),
      catchError((error) => {
        this.notificationService.errorMessage(
          error.error.message || 'Registration failed'
        );
        return throwError(error);
      })
    );
  }
  public checkUsername(username: string) {
    return this.http.get(
      `${environment.API_URL}/auth/check?username=${username}`
    );
  }

  public logout() {
    this.deleteToken();
    localStorage.removeItem('currentUser');
    this.currentUser$.next(null);
  }

  saveUserInLocalStorage(user: User) {
    localStorage.setItem('currentUser', JSON.stringify(user));
  }

  getUserFromLocalStorage(): User | null {
    const stringUserData = localStorage.getItem('currentUser');

    return stringUserData ? (JSON.parse(stringUserData) as User) : null;
  }
}

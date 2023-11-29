import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private successMessageSubject = new BehaviorSubject<string>("");
  successMessageAction$ = this.successMessageSubject.asObservable();
  private errorMessageSubject = new BehaviorSubject<string>("");
  errorMessageAction$ = this.successMessageSubject.asObservable();

  constructor() {}

  successMessage(message: string) {
    this.successMessageSubject.next(message);
  }

  errorMessage(message: string) {
    this.errorMessageSubject.next(message);
  }

  clearMessages() {
    this.successMessage('');
    this.errorMessage('');
  }
}

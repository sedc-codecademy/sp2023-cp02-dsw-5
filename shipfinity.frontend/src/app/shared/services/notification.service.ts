import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { NgToastService } from 'ng-angular-popup';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private successMessageSubject = new BehaviorSubject<string>("");
  successMessageAction$ = this.successMessageSubject.asObservable();
  private errorMessageSubject = new BehaviorSubject<string>("");
  errorMessageAction$ = this.successMessageSubject.asObservable();

  constructor(private toast: NgToastService) {}

  successMessage(message: string) {
    console.log(message);
    this.toast.success({detail: "Success", summary: message, duration: 3, sticky: true, position: 'topRight'});
  }

  errorMessage(message: string) {
    console.log(message);
    this.toast.error({detail: "Error", summary: message, duration: 3, sticky: true, position: 'topRight'});
  }
}

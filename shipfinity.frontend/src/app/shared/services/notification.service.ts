import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { NgToastService } from 'ng-angular-popup';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  successMessage(arg0: string) {
    throw new Error('Method not implemented.');
  }
  errorMessage(arg0: any) {
    throw new Error('Method not implemented.');
  }
  private successMessageSubject = new BehaviorSubject<string>('');
  successMessageAction$ = this.successMessageSubject.asObservable();

  // ...

  constructor(@Inject(NgToastService) private toast: NgToastService) {}

  // ...
}

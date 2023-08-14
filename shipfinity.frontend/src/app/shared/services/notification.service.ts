import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private successMessageSubject = new Subject<string>();
  successMessageAction$ = this.successMessageSubject.asObservable();

  constructor() { }

  successMessage(message: string){
    this.successMessageSubject.next(message);
  }

  clearMessages() {
    this.successMessage('');
  }
}

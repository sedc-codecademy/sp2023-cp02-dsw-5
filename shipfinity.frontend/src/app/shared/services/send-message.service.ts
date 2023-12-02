import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import IMessage from '../models/message';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class SendMessageService {

  constructor(private http: HttpClient, private notification: NotificationService) { }

  sendMessage(message: IMessage){
    return this.http.post(environment.SEND_MESSAGE_URL, message);
  }

  subscribeNewsletter(email: string){
    this.http.post(`${environment.API_URL}/newsletter/subscribe?email=${email}`, email)
    .subscribe({next: data => {
      this.notification.successMessage("Subscribed");
    },
    error: err => {
      this.notification.errorMessage("Failed");
    }})
  }
}

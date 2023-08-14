import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import IMessage from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class SendMessageService {

  constructor(private http: HttpClient) { }

  sendMessage(message: IMessage){
    return this.http.post(environment.SEND_MESSAGE_URL, message);
  }
}

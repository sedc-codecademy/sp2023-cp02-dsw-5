import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { BehaviorSubject, map } from 'rxjs';
import IMessage from '../models/message';

@Injectable({
  providedIn: 'root',
})
export class GetMessagesService {
  public messagesList$ = new BehaviorSubject<IMessage[]>([]);
  constructor(
    private http: HttpClient,
    private notification: NotificationService
  ) {}

  public getMessages() {
    this.http
      .get(`${environment.API_URL}/message`)
      .pipe(map((data) => data as IMessage[]))
      .subscribe({
        next: (data) => {
          this.messagesList$.next([...data]);
        },
        error: (err) => {
          this.notification.errorMessage(err.message);
        },
      });
  }
}

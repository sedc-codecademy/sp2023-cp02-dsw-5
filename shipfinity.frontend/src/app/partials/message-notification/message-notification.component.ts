import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-message-notification',
  templateUrl: './message-notification.component.html',
  styleUrls: ['./message-notification.component.css'],
})
export class MessageNotificationComponent {
  @Input() message: string;
}

import { GetMessagesService } from './../../../../shared/services/get-messages.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css'],
})
export class MessageListComponent implements OnInit {
  public messages$ = this.getMessagesService.messagesList$;

  constructor(private getMessagesService: GetMessagesService) {}

  ngOnInit(): void {
    this.getMessagesService.getMessages();
  }
}

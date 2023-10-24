import { Component } from '@angular/core';
import { SendMessageService } from '../../../shared/services/send-message.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {

  constructor(private messageService: SendMessageService){}

  submitContactForm(form:any){
    if(form.invalid){
      return;
    }
    let firstNameInput = form.form.controls.firstName.value;
    let lastNameInput = form.form.controls.lastName.value;
    let emailInput = form.form.controls.email.value;
    let subjectInput = form.form.controls.subject.value;
    let messageInput = form.form.controls.message.value;
    form.reset();

    this.messageService
      .sendMessage({firstName: firstNameInput, 
                    lastName: lastNameInput, 
                    email: emailInput, 
                    subject: subjectInput, 
                    message: messageInput})
      .subscribe(res => {
        console.log(res);
      });
  }
}

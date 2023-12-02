import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SendMessageService } from 'src/app/shared/services/send-message.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  newsletterForm: FormGroup;

  constructor(private message: SendMessageService){}

  ngOnInit(): void {
    this.newsletterForm = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email])
    });
  }

  submit(){
    if(this.newsletterForm.invalid) return;
    this.message.subscribeNewsletter(this.newsletterForm.value.email);
    this.newsletterForm.controls['email'].reset();
  }
}

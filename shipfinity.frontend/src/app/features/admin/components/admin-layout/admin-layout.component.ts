import { Component } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent {
  readonly adminString = "ADMINISTRATOR";
  currentUser$ = this.auth.currentUser$;
  constructor(private auth: AuthService){}
}

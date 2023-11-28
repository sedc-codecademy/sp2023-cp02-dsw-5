import { animate, keyframes, style, transition, trigger } from '@angular/animations';
import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-flyout',
  templateUrl: './flyout.component.html',
  styleUrls: ['./flyout.component.css'],
  animations: [
    trigger('openClose', [
      transition(':enter', [
        animate('250ms ease-out', keyframes([
          style({ transform: 'translateX(150%)', offset: 0}),
          style({ transform: 'translateX(0) scale(1)', offset: 1 })
        ]))
      ]),
      transition(':leave', [
        animate('350ms ease-in', style({ transform: 'translateX(150%)' }))
      ])
    ])
  ]
})
export class FlyoutComponent {

}

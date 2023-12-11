import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IOrderSellerList } from 'src/app/shared/models/order';
import { OrderService } from 'src/app/shared/services/order.service';
import { OrderManageComponent } from '../order-manage/order-manage.component';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  orders$ = this.orderService.sellerProducts$;

  constructor(private orderService: OrderService, private dialog: MatDialog, private notification: NotificationService){}
  ngOnInit(): void {
    this.orderService.getBySeller();
  }

  addBtnClick(){
  }

  shipOrder(order: IOrderSellerList){
    const ref = this.dialog.open(OrderManageComponent, { data: order });
    ref.afterClosed().subscribe(complete => {
      if (!complete) return;
      this.orderService.shipOrder(order.id).subscribe({
        next: _ => {
          this.notification.successMessage("Order has been shipped!");
          this.orderService.getBySeller();
        },
        error: err => this.notification.errorMessage("Cannot ship order")
      });
    })
  }
}

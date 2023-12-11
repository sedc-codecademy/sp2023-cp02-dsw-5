import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { IOrderSellerDetails, IOrderSellerList } from 'src/app/shared/models/order';
import { OrderService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-order-manage',
  templateUrl: './order-manage.component.html',
  styleUrls: ['./order-manage.component.css']
})
export class OrderManageComponent implements OnInit {
  order: IOrderSellerList;
  orderDetails$: Observable<IOrderSellerDetails>
  constructor(private orderService: OrderService, private dialogRef: MatDialogRef<OrderManageComponent>, @Inject(MAT_DIALOG_DATA) public data: IOrderSellerList){}
  ngOnInit(): void {
    this.order = this.data;
    this.orderDetails$ = this.orderService.getOrderDetails(this.order.id);
  }

  cancel(){
    this.dialogRef.close(false);
  }

  ship(){
    this.dialogRef.close(true);
  }
}

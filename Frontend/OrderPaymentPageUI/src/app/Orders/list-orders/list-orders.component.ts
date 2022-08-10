import { Component, OnInit } from '@angular/core';
import { OrderServiceService } from 'src/app/Services/order-service.service';

import { IOrder } from 'src/app/_models/iorder';
@Component({
  selector: 'app-list-orders',
  templateUrl: './list-orders.component.html',
  styleUrls: ['./list-orders.component.css']
})
export class ListOrdersComponent implements OnInit {
  public orders:IOrder[]|any = [];
  constructor(private orderSer:OrderServiceService) { }

  ngOnInit(): void {
    this.orderSer.getAllOrders().subscribe(
      data => {this.orders = data},
      error => {console.log(error)}
    )
  }
  refresh(){
    this.orderSer.getAllOrders().subscribe(
      data => {this.orders = data},
      error => {console.log(error)}
    )
  }

}

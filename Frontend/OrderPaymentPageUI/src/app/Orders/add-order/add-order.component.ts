import { Component, OnInit } from '@angular/core';
import { OrderServiceService } from 'src/app/Services/order-service.service';
import { IOrder } from 'src/app/_models/iorder';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  private order:IOrder|any = {};
  private clientId:number = 1;
  public displayFlag:boolean = false;
  constructor(private orderSer:OrderServiceService) { }

  ngOnInit(): void {
  }
  toggleAddForm(){
    this.displayFlag = true;
  }
  onAdd(value:any){
    this.order.title = value.title;
    this.order.itemPrice = value.itemPrice;
    this.order.quantity = value.quantity;
    this.order.clientId = this.clientId;
    this.orderSer.addOrder(this.order).subscribe(
      next => {this.displayFlag = false;},
      (error) => {console.log(error)}
    )
  }

}

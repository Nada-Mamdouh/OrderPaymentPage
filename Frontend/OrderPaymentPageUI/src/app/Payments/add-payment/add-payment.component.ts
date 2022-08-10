import { Component, Input, OnInit } from '@angular/core';

import { IPayment } from 'src/app/_models/ipayment';
import { PaymentServiceService } from 'src/app/Services/payment-service.service';
@Component({
  selector: 'app-add-payment',
  templateUrl: './add-payment.component.html',
  styleUrls: ['./add-payment.component.css']
})
export class AddPaymentComponent implements OnInit {
  private payment:IPayment|any = {}
  clientId:number = 1;
  public displayFlag:boolean = false;
  constructor(private paymentSer:PaymentServiceService) { }

  ngOnInit(): void {
  }
  toggleDisplay(){
    this.displayFlag = true;
  }
  public onAdd(value:any){
    this.payment.amountPaid = value.amount;
    this.payment.clientId = this.clientId;
    this.paymentSer.postPayment(this.payment).subscribe(
      next => {console.log(next);this.displayFlag = false;},
      error => {console.log(error)}
    )
  }

}

import { Component, OnInit } from '@angular/core';
import { PaymentServiceService } from 'src/app/Services/payment-service.service';

import { IPayment } from 'src/app/_models/ipayment';

@Component({
  selector: 'app-list-payments',
  templateUrl: './list-payments.component.html',
  styleUrls: ['./list-payments.component.css']
})
export class ListPaymentsComponent implements OnInit {
  public payments:IPayment[]|any = [];

  constructor(private paymentSer:PaymentServiceService) { }

  ngOnInit(): void {
    this.paymentSer.getAllPayments().subscribe(
      data => {this.payments = data;},
      error => {console.log(error)}
    )
  }
  refresh(){
    this.paymentSer.getAllPayments().subscribe(
      data => {this.payments = data;},
      error => {console.log(error)}
    )
  }


}

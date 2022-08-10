import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IPayment } from '../_models/ipayment';
@Injectable({
  providedIn: 'root'
})
export class PaymentServiceService {
  private paymentBaseUrl:string = "https://localhost:7117/api/Payments";
  constructor(private httpclient:HttpClient) { }
  public getAllPayments(): Observable<IPayment|any>{
    return this.httpclient.get(this.paymentBaseUrl);
  }
  public postPayment(payment:IPayment): Observable<IPayment|any>{
    return this.httpclient.post(this.paymentBaseUrl,payment);
  }
}

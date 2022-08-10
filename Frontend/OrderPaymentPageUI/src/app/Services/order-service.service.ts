import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IOrder } from '../_models/iorder';
@Injectable({
  providedIn: 'root'
})
export class OrderServiceService {
  private orderBaseUrl:string = "https://localhost:7117/api/Orders";

  constructor(private httpclient:HttpClient) { }

  public getAllOrders(): Observable<IOrder|any>{
    return this.httpclient.get(this.orderBaseUrl);
  }
  public addOrder(order:IOrder){
    return this.httpclient.post(this.orderBaseUrl,order);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IWalletViewModel } from '../_models/iwallet-view-model';
@Injectable({
  providedIn: 'root'
})
export class WalletServiceService {
  private walletBaseUrl:string = "https://localhost:7117/api/WalletBalance/";
  private creditSegment:string = "GetCreditBalance/";
  private debitSegment:string = "GetDebitBalance/";
  private totalPaidMoneySegment:string = "GetTotalPaidAmount/";
  private netMoneyOwedSegment:string = "GetNetOwedMoney/";
  private netMoneyOwnedSegment:string = "GetNetOwnedMoney/";
  private getWalletBalanceAfterDeduction:string = "GetWalletBalance/"
  private clientId:number = 1;
  public wallet:IWalletViewModel|any = {};

  constructor(private httpclient:HttpClient) { }

  public getCreditMoney(): Observable<number|any>{
    return this.httpclient.get(this.walletBaseUrl+this.creditSegment+this.clientId);
  }
  public getDebitMoney(): Observable<number|any>{
    return this.httpclient.get(this.walletBaseUrl+this.debitSegment+this.clientId);
  }
  public getTotalPaidMoney(): Observable<number|any>{
    return this.httpclient.get(this.walletBaseUrl+this.totalPaidMoneySegment+this.clientId);
  }
  public getNetOwedMoney(): Observable<number|any>{
    return this.httpclient.get(this.walletBaseUrl+this.netMoneyOwedSegment+this.clientId);
  }
  public getNetOwnedMoney(): Observable<number|any>{
    return this.httpclient.get(this.walletBaseUrl + this.netMoneyOwnedSegment + this.clientId);
  }
  public deductMoney(amount:number): Observable<IWalletViewModel|any>{
    return this.httpclient.get(this.walletBaseUrl+ this.getWalletBalanceAfterDeduction + this.clientId +"?amounttobededucted="+amount);
  }

}

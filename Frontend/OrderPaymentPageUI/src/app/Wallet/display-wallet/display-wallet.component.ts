import { Component, OnInit } from '@angular/core';
import { WalletServiceService } from 'src/app/Services/wallet-service.service';
import { IWalletViewModel } from 'src/app/_models/iwallet-view-model';

@Component({
  selector: 'app-display-wallet',
  templateUrl: './display-wallet.component.html',
  styleUrls: ['./display-wallet.component.css']
})
export class DisplayWalletComponent implements OnInit {
  public totalOrders:number = 0;
  public totalPayments:number = 0;
  public totalPaidMoney:number = 0;
  public moneyIOwe:number = 0;
  public moneyIOwn:number = 0;
  public walletBalance:number = 0;
  public amountInNumbers:number = 0.0;
  public displayWalletBalance:boolean = false;
  //public wallet:IWalletViewModel|any = {};
  constructor(private walletSer:WalletServiceService) { }

  ngOnInit(): void {
    this.walletSer.getCreditMoney().subscribe(
      data => {this.totalOrders = data},
      error => {console.log(error)}
    )
    this.walletSer.getDebitMoney().subscribe(
      data => {this.totalPayments = data},
      error => {console.log(error)}
    )
    this.walletSer.getTotalPaidMoney().subscribe(
      data => {this.totalPaidMoney = data;},
      error => {console.log(error)}
    )
    this.walletSer.getNetOwedMoney().subscribe(
      data => {this.moneyIOwe = data;},
      error => {console.log(error)}
    )
    this.walletSer.getNetOwnedMoney().subscribe(
      data => {this.moneyIOwn = data;},
      error => {console.log(error)}
    )
    this.walletBalance = 0.0;

  }
  onDeduct(amountToBeDeducted:string){
    this.amountInNumbers = parseFloat(amountToBeDeducted);
    console.log(this.amountInNumbers);
    this.walletSer.deductMoney(this.amountInNumbers).subscribe(
      data => {this.walletBalance= data.walletBalanceAfterDeduction;
                this.displayWalletBalance = true;
                this.moneyIOwe = data.netMoneyOwed;
                this.moneyIOwn = data.netMoneyOwned;
                console.log(data);
                },
      error => {console.log(error)}
    )
  }

}



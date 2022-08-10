import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DisplayClientComponent } from './Clients/display-client/display-client.component';
import { ListOrdersComponent } from './Orders/list-orders/list-orders.component';
import { ListPaymentsComponent } from './Payments/list-payments/list-payments.component';
import { DisplayWalletComponent } from './Wallet/display-wallet/display-wallet.component';
import { AddOrderComponent } from './Orders/add-order/add-order.component';
import { AddPaymentComponent } from './Payments/add-payment/add-payment.component';

@NgModule({
  declarations: [
    AppComponent,
    DisplayClientComponent,
    ListOrdersComponent,
    ListPaymentsComponent,
    DisplayWalletComponent,
    AddOrderComponent,
    AddPaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

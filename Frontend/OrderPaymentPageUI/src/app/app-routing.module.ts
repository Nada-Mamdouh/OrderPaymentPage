import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPaymentComponent } from './Payments/add-payment/add-payment.component';
import { ListPaymentsComponent } from './Payments/list-payments/list-payments.component';

const routes: Routes = [
  {path:"addpayment",component:AddPaymentComponent,outlet:'aux'},
  {path:"list-payments",component:ListPaymentsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

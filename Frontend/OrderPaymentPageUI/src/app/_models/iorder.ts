export interface IOrder {
  id:number,
  title:string,
  dateOrdered:Date,
  itemPrice:number,
  quantity:number,
  total:number,
  paidAmount:number,
  clientId:number
}

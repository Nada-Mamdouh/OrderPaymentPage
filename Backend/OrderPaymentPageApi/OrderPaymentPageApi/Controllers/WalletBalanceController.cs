using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Models;
using OrderPaymentPageApi.ViewModels;
using OrderPaymentPageApi.Repositories;

namespace OrderPaymentPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletBalanceController : ControllerBase
    {
        double AmountToBeDeducted = 0.0;
        WalletRepository walletRepo;
        IRepository<Client> clientRepo;
        IOrderUpdateRepository orderUpdateRepo; 
        WalletViewModel walletViewModel;

        public WalletBalanceController(WalletRepository walletRepo, 
                                       IRepository<Client> clientRepo,
                                       WalletViewModel walletViewModel,
                                       IOrderUpdateRepository orderUpdateRepo)
        {
            this.walletRepo = walletRepo;
            this.clientRepo = clientRepo;
            this.walletViewModel = walletViewModel;
            this.orderUpdateRepo = orderUpdateRepo;
        }
        /** get the credit balance, how much the client owe to our website */
        [HttpGet("GetCreditBalance/{clientid:int}")]
        public ActionResult GetCreditBalance(int clientid)
        {
            Client client = clientRepo.GetById(clientid);
            if (client != null)
            {
                List<Order> OrdersTheClientMade = walletRepo.getOrdersByClientId(clientid);
                if (OrdersTheClientMade == null) return NotFound("The client hasn't made any orders yet");
                else
                {
                    walletViewModel.Credit = walletRepo.calculateCreditAmounts(OrdersTheClientMade);
                    return Ok(walletViewModel.Credit);
                }
            }
            else return NotFound("No such a client exists in our system");
        }

        /** get the debit balance, how much money the client deposit in his/her wallet */
        [HttpGet("GetDebitBalance/{clientid:int}")]
        public ActionResult GetDebitBalance(int clientid)
        {
            Client client = clientRepo.GetById(clientid) ;
            if (client != null)
            {
                List<Payment> PaymentsTheClientMade = walletRepo.getPaymentsByClientId(clientid);
                //List<Payment> PaymentsTheClientMade = dbContext.Payments.Where(payment => payment.ClientId == clientid).ToList();
                if (PaymentsTheClientMade == null) return NotFound("The client hasn't made any payments yet");
                else
                {
                    walletViewModel.Debit = PaymentsTheClientMade.Sum(payment => payment.AmountPaid);
                    return Ok(walletViewModel.Debit);
                }
            }
            else return NotFound("No such a client exists in our system");
        }

        /** get total paid money (sum of paid money column in orders table)*/
        [HttpGet("GetTotalPaidAmount/{clientid:int}")]
        public ActionResult GetTotalPaidMoney(int clientid)
        {
            Client client = clientRepo.GetById(clientid);
            if (client != null)
            {
                List<Order> OrdersTheClientMade = walletRepo.getOrdersByClientId(clientid);
                if (OrdersTheClientMade == null) return NotFound("The client hasn't made any orders yet");
                else
                {
                    walletViewModel.TotalPaidMoney = walletRepo.calculateTotalPaidMoney(OrdersTheClientMade);
                    return Ok(walletViewModel.TotalPaidMoney);
                }
            }
            else return NotFound("No such a client exists in our system");
        }
        /** Get net money Iowe */
        [HttpGet("GetNetOwedMoney/{clientid:int}")]
        public ActionResult GetNetMoneyIOwe(int clientid)
        {
            Client client = clientRepo.GetById(clientid);
            if (client != null)
            {
                List<Order> OrdersTheClientMade = walletRepo.getOrdersByClientId(clientid);
                if (OrdersTheClientMade == null) return NotFound("The client hasn't made any orders yet");
                else
                {
                    walletViewModel.NetMoneyOwed = walletRepo.calculateNetMoneyIowe(OrdersTheClientMade);
                    return Ok(walletViewModel.NetMoneyOwed);
                }
            }
            else return NotFound("No such a client exists in our system");
        }
        
        /** Get net money Iown */
        [HttpGet("GetNetOwnedMoney/{clientid:int}")]
        public ActionResult GetNetMoneyIOwn(int clientid)
        {

            Client client = clientRepo.GetById(clientid);
            if (client != null)
            {
                List<Order> OrdersTheClientMade = walletRepo.getOrdersByClientId(clientid);
                List<Payment> PaymentsTheClientMade = walletRepo.getPaymentsByClientId(clientid);

                if (OrdersTheClientMade == null) return NotFound("The client hasn't made any orders yet");
                else
                {
                    walletViewModel.NetMoneyOwned = walletRepo.calculateNetMoneyIown(PaymentsTheClientMade,OrdersTheClientMade);
                    return Ok(walletViewModel.NetMoneyOwned);
                }
            }
            else return NotFound("No such a client exists in our system");
        }
        /** (post) pay off part of client's debt */
        [HttpGet("GetWalletBalance/{clientid:int}")]
        public ActionResult PayOffPartOfDept(int clientid,[FromQuery]double amounttobededucted)
        {
            List<Order> OrdersTheClientMade = walletRepo.getOrdersByClientId(clientid);
            List<Payment> PaymentsTheClientMade = walletRepo.getPaymentsByClientId(clientid);
            walletViewModel.Debit = walletRepo.claculateDebitAmounts(PaymentsTheClientMade);
            walletViewModel.Credit = walletRepo.calculateCreditAmounts(OrdersTheClientMade);
            walletViewModel.TotalPaidMoney = walletRepo.calculateTotalPaidMoney(OrdersTheClientMade);
            AmountToBeDeducted = amounttobededucted;
            Client client = clientRepo.GetById(clientid);

            /** Checking if the amount is less than or equal money user has in his wallet so we can subtract or deduct it*/
            bool canDeductThisAmount = ((walletViewModel.Debit - walletViewModel.TotalPaidMoney) - amounttobededucted) >= 0;
            if (client != null && canDeductThisAmount)
            {
                if (OrdersTheClientMade == null) return NotFound("The client hasn't made any orders yet");
                else
                {
                    /** Checking if the amount is less than or equal or greater than money 
                     * he owes to the website if 
                     * it's greater then we will only deduct or subtract credit money */
                    double DifferenceBetweenCreditAndAmountToBeDeducted = walletViewModel.Credit - amounttobededucted;
                    if (DifferenceBetweenCreditAndAmountToBeDeducted >= 0)
                    {
                        walletViewModel.WalletBalanceAfterDeduction = (walletViewModel.Debit - walletViewModel.TotalPaidMoney) - amounttobededucted;
                    }
                    else
                    {
                        walletViewModel.WalletBalanceAfterDeduction = (walletViewModel.Debit - walletViewModel.TotalPaidMoney) - walletViewModel.Credit;
                    }
                    List<Order> orders = orderUpdateRepo.orderByDate(OrdersTheClientMade);
                    try
                    {
                        /** sending this amount to get subtracted/deducted from paid money in orders table (function in order repository)*/
                        orderUpdateRepo.deduct(AmountToBeDeducted, orders);
                        /** returning new values after deduction */
                        walletViewModel.TotalPaidMoney = walletRepo.calculateTotalPaidMoney(orders);
                        walletViewModel.NetMoneyOwned = walletRepo.calculateNetMoneyIown(PaymentsTheClientMade,orders);
                        walletViewModel.NetMoneyOwed = walletRepo.calculateNetMoneyIowe(orders);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                    return Ok(walletViewModel);
                }
            }
            else if (client == null) return NotFound("No such a client exists in our system");
            else return BadRequest("Amount must be less than or equal to Debit Balance maximum ");
        }
        
    }
    
}

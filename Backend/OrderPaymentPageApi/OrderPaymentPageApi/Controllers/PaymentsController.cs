using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Repositories;
using OrderPaymentPageApi.Models;

namespace OrderPaymentPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IRepository<Payment> paymentRepo;
        IPaymentUpdateRepository paymentUpdateRepo;
        public PaymentsController(IRepository<Payment> paymentRepo,
                                  IPaymentUpdateRepository paymentUpdateRepo)
        {
            this.paymentRepo = paymentRepo;
            this.paymentUpdateRepo = paymentUpdateRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(paymentRepo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Payment payment = paymentRepo.GetById(id);
            if (payment == null) return NotFound();
            else return Ok(payment);
        }
        [HttpGet("clientpayments/{id:int}")]
        public IActionResult GetByClientId(int id)
        {
            List<Payment> payments = paymentUpdateRepo.GetByClientId(id);
            if (payments == null) return NotFound();
            else return Ok(payments);
        }
        [HttpPost]
        public IActionResult Add(Payment payment)
        {
            if (ModelState.IsValid && payment != null)
            {
                try
                {
                    paymentRepo.Add(payment);
                    return Created("GetAll", payment);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
                return BadRequest(ModelState);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Models;

using OrderPaymentPageApi.Repositories;
namespace OrderPaymentPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        IRepository<Order> orderRepo;
        IOrderUpdateRepository orderUpdateRepo;
        public OrdersController(IRepository<Order> orderRepo,IOrderUpdateRepository orderUpdateRepo)
        {
            this.orderRepo = orderRepo;
            this.orderUpdateRepo = orderUpdateRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(orderRepo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Order order = orderRepo.GetById(id);
            if (order == null) return NotFound();
            else return Ok(order);
        }
        [HttpGet("clientorders/{id:int}")]
        public IActionResult GetByClientId(int id)
        {
            List<Order> orders = orderUpdateRepo.GetByClientId(id);
            if (orders == null) return NotFound();
            else return Ok(orders);
        }
        [HttpPost]
        public IActionResult Add(Order order)
        {
            if(ModelState.IsValid && order != null)
            {
                try
                {
                    orderRepo.Add(order);
                    return Created("GetAll",order);
                }catch(Exception ex)
                {
                    return StatusCode(500,ex.Message);
                }
            }else
                return BadRequest(ModelState);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderPaymentPageApi.Data;
using OrderPaymentPageApi.Repositories;
using OrderPaymentPageApi.Models;

namespace OrderPaymentPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        IRepository<Client> clientRepo;
        public ClientsController(IRepository<Client> clientRepo)
        {
            this.clientRepo = clientRepo;   
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(clientRepo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Client client = clientRepo.GetById(id);
            if (client == null) return NotFound();
            else return Ok(client);
        }
        [HttpPost]
        public IActionResult Add(Client client)
        {
            if (ModelState.IsValid && client != null)
            {
                try
                {
                    clientRepo.Add(client);
                    return Created("GetAll", client);
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

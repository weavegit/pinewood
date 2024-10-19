using Data;
using Microsoft.AspNetCore.Mvc;
using Common.Entities;
using PinewoodApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PinewoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ApplicationDbContext ctx) : ControllerBase
    {
        private readonly ApplicationDbContext ctx = ctx;

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ctx.Customers.ToList());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = GetCustomer(id);
            if (customer is null) {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerDto customerDto)
        {
            var customerEntity = new Customer(
               Guid.NewGuid(), 
                customerDto.Name,
                customerDto.PhoneNumber,
                customerDto.Town,  
                customerDto.Comments, 
                customerDto.YourReference);
            try
            {

                ctx.Customers.Add(customerEntity);
                ctx.SaveChanges();
            }
            catch (Exception ex) { }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CustomerDto customerDto)
        {
            var customer = GetCustomer(id);
            if (customer is null)
            {
                return NotFound();
            }

            customer.Name = customerDto.Name;
            customer.Town = customerDto.Town;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Comments = customerDto.Comments;
            customer.YourReference = customerDto.YourReference;

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex) { }

            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var customer = GetCustomer(id);
            if (customer is null)
            {
                return NotFound();
            }

            try { 
                ctx.Customers.Remove(customer);
                ctx.SaveChanges();
            }
            catch (Exception ex) { }

            return Ok();
        }

        private Customer? GetCustomer(Guid id)
        {
            var customer = (ctx.Customers.Find(id));

            return customer;
        }
    }
}

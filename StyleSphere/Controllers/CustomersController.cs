using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using StyleSphere.ViewModels;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly StyleSphereDbContext _context;

        public CustomersController(StyleSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //Get Favorites By CustomerId
        [Route("favorites/{customerId}")]
        [HttpGet]
        public async Task<ICollection<FavbyCustomerIdViewModel>> GetFavoritesByCustomerID(int customerId)
        {
            //return await (from favourite in _context.Favorites
            //              join product in _context.Products on favourite.ProductId equals product.ProductId
            //              where favourite.CustomerId == customerId
            //              select new FavbyCustomerIdViewModel
            //              {
            //                  ProductId = product.ProductId,
            //                  Name = product.ProductName,
            //                  Description = product.Description
            //              }).ToListAsync();
            return await _context.Favorites
        .Join(_context.Products, favourite => favourite.ProductId, product => product.ProductId, (favourite, product) => new { favourite, product })
        .Where(x => x.favourite.CustomerId == customerId)
        .Select(x => new FavbyCustomerIdViewModel
        {
            ProductId = x.product.ProductId,
            Name = x.product.ProductName,
            Description = x.product.Description
        })
        .ToListAsync();
        }

        [Route("CustomerLogin")]
        [HttpPost]
        public async Task<ActionResult<Customer>> CustomerLogin(string username,string password)
        {
            // return await _context.products.tolistasync();
            var logininfo = _context.Customers.Where(c => c.Email==username && c.Password==password).ToList();
            
            return Ok(logininfo);
        }



        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}

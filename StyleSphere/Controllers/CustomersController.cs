using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using StyleSphere.ViewModels;
using StyleSphere.Services;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly StyleSphereDbContext _context;

        private readonly ICustomerService _customerService;

        public CustomersController(StyleSphereDbContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public IActionResult getCustomerbyId(int id)
        {
            var customer = _customerService.getCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);  
        }


        [Route("CustomerLogin")]
        [HttpGet]
        public async Task<IActionResult> login(string email, string password)
        {
            return await _customerService.loginCustomer(email, password);
        }
    


        //// GET: api/Customers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        //{
        //    return await _context.Customers.ToListAsync();
        //}

        //// GET: api/Customers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}

        //// PUT: api/Customers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("PostCustomer")]
        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            return await _customerService.postCustomer(customer);
        }

        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


        ////get favorites by customerid
        //[Route("favorites/{customerid}")]
        //[HttpGet]
        //public async Task<ICollection<FavbyCustomerIdViewModel>> getfavoritesbycustomerid(int customerid)
        //{
        //    //return await (from favourite in _context.favorites
        //    //              join product in _context.products on favourite.productid equals product.productid
        //    //              where favourite.customerid == customerid
        //    //              select new favbycustomeridviewmodel
        //    //              {
        //    //                  productid = product.productid,
        //    //                  name = product.productname,
        //    //                  description = product.description
        //    //              }).tolistasync();
        //    return await _context.Favorites
        //.Join(_context.Products, Favourite => Favourite.ProductId, product => product.ProductId, (favourite, product) => new { favourite, product })
        //.Where(x => x.favourite.CustomerId == customerid)
        //.Select(x => new FavbyCustomerIdViewModel
        //{
            
        //    ProductId = x.product.ProductId,
        //    Name = x.product.ProductName,
        //    Description = x.product.Description
        //})
        //.ToListAsync();
        //}

        //[Route("CustomerLogin")]
        //[HttpGet]
        //public async Task<ActionResult> CustomerLogin(string email,string password)
        //{
        //    // return await _context.products.tolistasync();
        //    var response = new UserloginResponse();
        //    var logininfo = await _context.Customers.Where(c => c.Email==email).FirstOrDefaultAsync();
            
        //    if(logininfo!=null)
        //    {
        //        if(password != logininfo.Password)
        //        {
        //            response.IsSuccess = false;
        //            response.ErrorMessage = "Invaild Password";
        //            return BadRequest("Password doesn't exist");
        //        }
        //        else
        //        {
        //            response.IsSuccess = true;
        //            response.ErrorMessage = "Success";
        //            return Ok("Valid userId and password");
        //        }
        //    }
        //    else
        //    {
        //        response.IsSuccess = false;
        //        response.ErrorMessage = "User doesn't exist";
        //        return BadRequest("User doesn't exist");
        //    }

            
        //}


        private bool CustomerExists(string email)
        {
            return _context.Customers.Any(e => e.Email == email);
        }
    }
}

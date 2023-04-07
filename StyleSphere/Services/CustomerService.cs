using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly StyleSphereDbContext _context;

        public CustomerService(StyleSphereDbContext context)
        {
            _context = context;
        }

        public Customer getCustomer(int custId)
        {
            return _context.Customers.Find(custId);
        }
        public async Task<IActionResult> postCustomer(Customer customerobj)
        {
            _context.Customers.Add(customerobj);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("PostCustomer", "Customers", new { id = customerobj.CustomerId }, customerobj);
        }

        public async Task<IActionResult> loginCustomer(string email,string password)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Email == email);
            if (customer == null || customer.Password != password)
            {
                return new BadRequestObjectResult("Invalid Email or Password");
            }
            return new OkObjectResult(customer);
        }
    }
}

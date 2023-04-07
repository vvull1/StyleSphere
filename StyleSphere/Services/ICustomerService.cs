using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public interface ICustomerService
    {
        public Customer getCustomer(int custId);

        public Task<IActionResult> postCustomer(Customer customerobj);

        public Task<IActionResult> loginCustomer(string email,string password);
    }
}

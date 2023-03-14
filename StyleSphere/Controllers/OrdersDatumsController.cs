using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using StyleSphere.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDatumsController : ControllerBase
    {
        private readonly StyleSphereDbContext _context;

        public OrdersDatumsController(StyleSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdersDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersDatum>>> GetOrdersData()
        {
            return await _context.OrdersData.ToListAsync();
        }

        // GET: api/OrdersDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDatum>> GetOrdersDatum(int id)
        {
            var ordersDatum = await _context.OrdersData.FindAsync(id);

            if (ordersDatum == null)
            {
                return NotFound();
            }

            return ordersDatum;
        }

        // PUT: api/OrdersDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersDatum(int id, OrdersDatum ordersDatum)
        {
            if (id != ordersDatum.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(ordersDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersDatumExists(id))
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

        // POST: api/OrdersDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersDatum>> PostOrdersDatum(OrdersDatum ordersDatum)
        {
            _context.OrdersData.Add(ordersDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersDatum", new { id = ordersDatum.OrderId }, ordersDatum);
        }

        // DELETE: api/OrdersDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersDatum(int id)
        {
            var ordersDatum = await _context.OrdersData.FindAsync(id);
            if (ordersDatum == null)
            {
                return NotFound();
            }

            _context.OrdersData.Remove(ordersDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Orders/{customerId}")]
        public async Task<List<OrdersbyCustomerIdViewModel>> GetOrdersByCustomerID(int customerId)
        {
            //var customerOrders = await (from order in _context.OrdersData
            //                            where order.CustomerId == customerId
            //                            join orderDetail in _context.OrderDetails
            //                            on order.OrderId equals orderDetail.OrderId
            //                            join productMapping in _context.ProductMappings
            //                            on orderDetail.ProductMappingId equals productMapping.ProductMappingId
            //                            join product in _context.Products
            //                            on productMapping.ProductId equals product.ProductId
            //                            select new OrdersbyCustomerIdViewModel
            //                            {
            //                                OrderId = order.OrderId,
            //                                ProductId = product.ProductId,
            //                                OrderDate = order.OrderDate,
            //                                TrackingId = order.TrackingId,
            //                                ProductName = product.ProductName,
            //                                ProductDescription = product.Description
            //                            }).ToListAsync();

            //return customerOrders;

            var customerOrders = await _context.OrdersData
        .Where(order => order.CustomerId == customerId)
        .Join(_context.OrderDetails, order => order.OrderId, orderDetail => orderDetail.OrderId, (order, orderDetail) => new { order, orderDetail })
        .Join(_context.ProductMappings, od => od.orderDetail.ProductMappingId, pm => pm.ProductMappingId, (od, pm) => new { od, pm })
        .Join(_context.Products, odp => odp.pm.ProductId, product => product.ProductId, (odp, product) => new OrdersbyCustomerIdViewModel
        {
            OrderId = odp.od.order.OrderId,
           // ProductId = product.ProductId,
            OrderDate = odp.od.order.OrderDate,
            TrackingId = odp.od.order.TrackingId,
           // ProductName = product.ProductName,
           // ProductDescription = product.Description
        })
        .ToListAsync();

            return customerOrders;
        }

        [HttpGet]
        [Route("GetOrdersbyCustomerId")]
        public async Task<List<OrdersbyCustomerIdViewModel>> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _context.OrdersData.Where(o => o.CustomerId == customerId)
                .Select(o => new OrdersbyCustomerIdViewModel
                {
                    OrderId = o.OrderId,                    
                    CustomerId= o.CustomerId,
                    OrderDate = o.OrderDate,
                    ShippingAddress= o.ShippingAddress,
                    BillingAddress= o.BillingAddress,
                    TrackingId=o.TrackingId,
                })
                .ToListAsync();

            return orders;
        }

       


        //CheckOut Api
        [Route("CheckoutApi")]
        [HttpGet]
        public async Task<ActionResult<CheckOutViewModel>> GetOrdersData(int Customerid)
        {

            var tblordersdata = _context.OrdersData.Where(a => a.CustomerId == Customerid).ToList();
                        // For View Model
            List<CheckOutViewModel> models = new List<CheckOutViewModel>();

            foreach (var item in tblordersdata)
            {
                CheckOutViewModel model = new CheckOutViewModel();
                model.OrderId = item.OrderId;
                model.CustomerId = item.CustomerId;
                model.OrderDate = item.OrderDate;
                model.ShippingAddress = item.ShippingAddress;
                model.BillingAddress = item.BillingAddress;
                model.TrackingId = item.TrackingId;
                foreach (var items in item.OrderDetails)
                {
                    model.ProductName = items.ProductMapping.Product.ProductName;
                    model.ThumbnailImage = items.ProductMapping.Product.ThumbnailImage;
                    model.Quantity = items.Quantity;
                    model.Price = items.Price;
                    model.Color = items.ProductMapping.Color.Color;
                    model.Eusize = items.ProductMapping.Size.Eusize;
                    model.Ussize = items.ProductMapping.Size.Ussize;

                }
                models.Add(model);
            }
            return Ok(models);
        }
       
            


            private bool OrdersDatumExists(int id)
        {
            return _context.OrdersData.Any(e => e.OrderId == id);
        }
    }
}

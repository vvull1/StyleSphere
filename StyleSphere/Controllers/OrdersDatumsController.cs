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

        //// GET: api/OrdersDatums
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrdersDatum>>> GetOrdersData()
        //{
        //    return await _context.OrdersData.ToListAsync();
        //}

        //// GET: api/OrdersDatums/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<OrdersDatum>> GetOrdersDatum(int id)
        //{
        //    var ordersDatum = await _context.OrdersData.FindAsync(id);

        //    if (ordersDatum == null)
        //    {
        //        return NotFound();
        //    }

        //    return ordersDatum;
        //}

        //// PUT: api/OrdersDatums/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrdersDatum(int id, OrdersDatum ordersDatum)
        //{
        //    if (id != ordersDatum.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ordersDatum).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrdersDatumExists(id))
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

        //// POST: api/OrdersDatums
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<OrdersDatum>> PostOrdersDatum(OrdersDatum ordersDatum)
        //{
        //    _context.OrdersData.Add(ordersDatum);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrdersDatum", new { id = ordersDatum.OrderId }, ordersDatum);
        //}

        //// DELETE: api/OrdersDatums/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrdersDatum(int id)
        //{
        //    var ordersDatum = await _context.OrdersData.FindAsync(id);
        //    if (ordersDatum == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.OrdersData.Remove(ordersDatum);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpGet("Orders/{customerId}")]
        //public async Task<List<OrdersbyCustomerIdViewModel>> GetOrdersByCustomerID(int customerId)
        //{
        //    //var customerOrders = await (from order in _context.OrdersData
        //    //                            where order.CustomerId == customerId
        //    //                            join orderDetail in _context.OrderDetails
        //    //                            on order.OrderId equals orderDetail.OrderId
        //    //                            join productMapping in _context.ProductMappings
        //    //                            on orderDetail.ProductMappingId equals productMapping.ProductMappingId
        //    //                            join product in _context.Products
        //    //                            on productMapping.ProductId equals product.ProductId
        //    //                            select new OrdersbyCustomerIdViewModel
        //    //                            {
        //    //                                OrderId = order.OrderId,
        //    //                                ProductId = product.ProductId,
        //    //                                OrderDate = order.OrderDate,
        //    //                                TrackingId = order.TrackingId,
        //    //                                ProductName = product.ProductName,
        //    //                                ProductDescription = product.Description
        //    //                            }).ToListAsync();

        //    //return customerOrders;

        //    var customerOrders = await _context.OrdersData
        //.Where(order => order.CustomerId == customerId)
        //.Join(_context.OrderDetails, order => order.OrderId, orderDetail => orderDetail.OrderId, (order, orderDetail) => new { order, orderDetail })
        //.Join(_context.ProductMappings, od => od.orderDetail.ProductMappingId, pm => pm.ProductMappingId, (od, pm) => new { od, pm })
        //.Join(_context.Products, odp => odp.pm.ProductId, product => product.ProductId, (odp, product) => new OrdersbyCustomerIdViewModel
        //{
        //    OrderId = odp.od.order.OrderId,
        //   // ProductId = product.ProductId,
        //    OrderDate = odp.od.order.OrderDate,
        //    TrackingId = odp.od.order.TrackingId,
        //   // ProductName = product.ProductName,
        //   // ProductDescription = product.Description
        //})
        //.ToListAsync();

        //    return customerOrders;
        //}

        [HttpGet]
        [Route("GetOrdersbyCustomerId")]
        public async Task<ActionResult<OrdersbyCustomerIdViewModel>> GetOrdersByCustomerId(int customerId)
        {
            var orders = _context.OrdersData.Where(o => o.CustomerId == customerId)
                .Select(o => new OrdersbyCustomerIdViewModel
                {
                    OrderId = o.OrderId,                    
                    CustomerId= o.CustomerId,
                    OrderDate = o.OrderDate,
                    ShippingAddress= o.ShippingAddress,
                    BillingAddress= o.BillingAddress,
                    TrackingId=o.TrackingId,
                    NetAmount=o.NetAmount,
                })
                .ToList();
            if(orders==null)
            {
                return NotFound();
            }

            return Ok(orders);
        }




        //CheckOut Api
        [Route("CheckoutApi")]
        [HttpPost]
        public async Task<ActionResult<string>> GetOrdersData(CheckOutViewModel order)
        {

            //var tblordersdata = _context.OrdersData.Where(a => a.CustomerId == Customerid).ToList();
            //            // For View Model
            //List<CheckOutViewModel> models = new List<CheckOutViewModel>();

            //foreach (var item in tblordersdata)
            //{
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    OrdersDatum model = new OrdersDatum();
                    model.OrderId = order.OrderId;
                    model.CustomerId = order.CustomerId;
                    model.OrderDate = order.OrderDate;
                    model.ShippingAddress = order.ShippingAddress;
                    model.BillingAddress = order.BillingAddress;
                    model.TrackingId = order.TrackingId;
                    model.NetAmount = order.NetAmount;
                    model.ActiveStatus = order.ActiveStatus;
                    _context.OrdersData.Add(model);
                    await _context.SaveChangesAsync();
                    foreach (var items in order.OrderDetails)
                    {
                        OrderDetail detail = new OrderDetail();
                        detail.Quantity = items.Quantity;
                        detail.Price = items.Price;
                        detail.ProductMappingId = items.ProductMappingId;
                        detail.OrderId = model.OrderId;
                        detail.Total = items.Total;
                        detail.ActiveStatus = true;
                        _context.OrderDetails.Add(detail);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                    return Ok(model.OrderId.ToString());
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Ok(ex.Message);
                }
            }
        }
       
            


            private bool OrdersDatumExists(int id)
        {
            return _context.OrdersData.Any(e => e.OrderId == id);
        }
    }
}

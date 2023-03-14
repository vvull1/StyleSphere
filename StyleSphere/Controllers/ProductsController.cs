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
    public class ProductsController : ControllerBase
    {
        private readonly StyleSphereDbContext _context;

        public ProductsController(StyleSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>>getproducts()
        {
            // return await _context.products.tolistasync();
            List<ProductViewModel> products = new List<ProductViewModel>();
            var product = _context.Products.ToList();
            products = GetProductViewModels(products, product);
            return Ok(products);
        }

        //public async Task<ActionResult<List<ProductViewModel>>> GetAllProducts()
        //{
        //    var products = await _context.Products.ToListAsync();

        //    if (products == null)
        //    {
        //        return NotFound();
        //    }

        //    List<ProductViewModel> productList = new List<ProductViewModel>();

        //    foreach (var product in products)
        //    {
        //        ProductViewModel model = new ProductViewModel();
        //        model.ProductId = product.ProductId;
        //        model.ProductName = product.ProductName;
        //        model.Image1 = product.Image1;
        //        model.Image2 = product.Image2;
        //        model.Image3 = product.Image3;
        //        model.ThumbnailImage = product.ThumbnailImage;
        //        model.Price = product.Price;
        //        model.Description = product.Description;
        //        model.ColorCount = product.ProductMappings.Select(a => a.ColorId).Distinct().Count();
        //        model.NoofRatings = product.Ratings.Count();
        //        model.Ratings = (product.Ratings.Select(a => a.Rating1).Sum() / product.Ratings.Count());

        //        List<SizesMaster> sizeList = new List<SizesMaster>();
        //        List<ColorMaster> ColorList = new List<ColorMaster>();
        //        foreach (var item in product.ProductMappings)
        //        {
        //            var colorData = _context.ColorMasters.Where(a => a.ColorId == item.ColorId).FirstOrDefault();
        //            var sizeData = _context.SizesMasters.Where(a => a.SizeId == item.SizeId).FirstOrDefault();

        //            SizesMaster objSize = new SizesMaster();
        //            objSize.SizeId = item.SizeId;
        //            objSize.Eusize = sizeData.Eusize;
        //            objSize.Ussize = sizeData.Ussize;
        //            sizeList.Add(objSize);

        //            ColorMaster objColor = new ColorMaster();
        //            objColor.ColorId = item.ColorId;
        //            objColor.Color = colorData.Color;
        //            ColorList.Add(objColor);
        //        }
        //        model.ColorList = ColorList;
        //        model.SizeList = sizeList;

        //        productList.Add(model);
        //    }

        //    return productList;
        //}


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            List<ProductViewModel> products= new List<ProductViewModel>();
            var product = _context.Products.Where(e => e.ProductId == id).ToList();
            products = GetProductViewModels(products,product);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        ////GET PRODUCTS BY CATEGORY ID
        //[HttpGet("category/{categoryId}")]
        //public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsByCategory(int categoryId)
        //{
        //    var products = await _context.Products
        //        .Where(p => p.CategoryId ==categoryId)
        //        .Select(p => new ProductViewModel
        //        {
        //            ProductId = p.ProductId,
        //            ProductName = p.ProductName,
        //            Image1 = p.Image1,
        //            Image2 = p.Image2,
        //            Image3 = p.Image3,
        //            ThumbnailImage = p.ThumbnailImage,
        //            Price = p.Price,
        //            Description = p.Description,
        //            ColorCount = p.ProductMappings.Select(a => a.ColorId).Distinct().Count(),
        //            NoofRatings = p.Ratings.Count(),
        //            Ratings = p.Ratings.Select(a => a.Rating1).Sum() / p.Ratings.Count(),
        //            ColorList = p.ProductMappings.Select(a => a.Color).Distinct().ToList(),
        //            SizeList = p.ProductMappings.Select(a => a.Size).Distinct().ToList()
        //        })
        //        .ToListAsync();

        //    if (products == null)
        //    {
        //        return NotFound();
        //    }

        //    return products;
        //}


        ////GET PRODUCTS BY PRICE
        //[HttpGet("byprice")]
        //public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductByPrice(decimal minPrice, decimal maxPrice)
        //{
        //    var products = await _context.Products
        //        .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
        //        .Select(p => new ProductViewModel
        //        {
        //            ProductId = p.ProductId,
        //            ProductName = p.ProductName,
        //            Image1 = p.Image1,
        //            Image2 = p.Image2,
        //            Image3 = p.Image3,
        //            ThumbnailImage = p.ThumbnailImage,
        //            Price = p.Price,
        //            Description = p.Description,
        //            ColorCount = p.ProductMappings.Select(a => a.ColorId).Distinct().Count(),
        //            NoofRatings = p.Ratings.Count(),
        //            Ratings = p.Ratings.Select(a => a.Rating1).Sum() / p.Ratings.Count(),
        //            //SizeList = p.ProductMappings.Select(pm => new SizesMaster
        //            //{
        //            //    SizeId = pm.SizeId,
        //            //    Eusize = pm.SizesMaster.Eusize,
        //            //    Ussize = pm.SizesMaster.Ussize
        //            //}).ToList(),
        //            //ColorList = p.ProductMappings.Select(pm => new ColorMaster
        //            //{
        //            //    ColorId = pm.ColorId,
        //            //    Color = pm.ColorMaster.Color
        //            //}).ToList()
        //        })
        //        .ToListAsync();

        //    return products;
        //}



        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        private List<ProductViewModel> GetProductViewModels(List<ProductViewModel> products, List<Product> product)
        {
            foreach (var items in product)
            {


                ProductViewModel model = new ProductViewModel();
                model.ProductId = items.ProductId;
                model.ProductName = items.ProductName;
                model.Image1 = items.Image1;
                model.Image2 = items.Image2;
                model.Image3 = items.Image3;
                model.ThumbnailImage = items.ThumbnailImage;
                model.Price = items.Price;
                model.Description = items.Description;
                model.ColorCount = items.ProductMappings.Select(a => a.ColorId).Distinct().Count();
                model.NoofRatings = items.Ratings.Count();
                model.Ratings = (items.Ratings.Select(a => a.Rating1).Sum() / items.Ratings.Count());

                List<SizesMaster> sizeList = new List<SizesMaster>();
                List<ColorMaster> ColorList = new List<ColorMaster>();
                foreach (var item in items.ProductMappings)
                {
                    var colorData = _context.ColorMasters.Where(a => a.ColorId == item.ColorId).FirstOrDefault();
                    var sizeData = _context.SizesMasters.Where(a => a.SizeId == item.SizeId).FirstOrDefault();

                    SizesMaster objSize = new SizesMaster();
                    objSize.SizeId = item.SizeId;
                    objSize.Eusize = sizeData.Eusize;
                    objSize.Ussize = sizeData.Ussize;
                    sizeList.Add(objSize);

                    ColorMaster objColor = new ColorMaster();
                    objColor.ColorId = item.ColorId;
                    objColor.Color = colorData.Color;
                    ColorList.Add(objColor);
                }
                model.ColorList = ColorList;
                model.SizeList = sizeList;
                products.Add(model);
            }
            return products;
        }



        // GET: api/ProductsbyCategories
        [Route("GetProductbyCategory")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> getproductbycategory(int id)
        {
            // return await _context.products.tolistasync();
            List<ProductViewModel> products = new List<ProductViewModel>();
            var product = _context.Products.Where(a => a.CategoryId == id).ToList();
            products = GetProductViewModels(products, product);
            return Ok(products);
        }

        // GET: api/ProductsbySubCategories
        [Route("GetProductbySubCategory")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> getproductbysubcategory(int id)
        {
            // return await _context.products.tolistasync();
            List<ProductViewModel> products = new List<ProductViewModel>();
            var product = _context.Products.Where(a => a.SubCategoryId == id).ToList();
            products = GetProductViewModels(products, product);
            return Ok(products);
        }

        // GET: api/ProductUnderPrice
        [Route("GetProductUnderPrice")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> getproductunderprice(decimal maxprice)
        {
            // return await _context.products.tolistasync();
            List<ProductViewModel> products = new List<ProductViewModel>();
            var product = _context.Products.Where(p => p.Price <= maxprice).ToList();
            products = GetProductViewModels(products, product);
            return Ok(products);
        }

        
        //Search api for product

        [Route("SearchbyProduct")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> getproductbysearch(string text)
        {
            // return await _context.products.tolistasync();
            List<ProductViewModel> products = new List<ProductViewModel>();
            var product = _context.Products.Where(s => s.ProductName.Contains(text) || s.Description.Contains(text)).ToList();
            products = GetProductViewModels(products, product);
            return Ok(products);
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly StyleSphereDbContext _context;

        public FavoritesController(StyleSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/Favorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorites()
        {
            return await _context.Favorites.ToListAsync();
        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        // PUT: api/Favorites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Favorite favorite)
        {
            if (id != favorite.FavoritesId)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/Favorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.FavoritesId }, favorite);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/GetFavoritesbyCustomerId/5
        [Route("GetFavoritesbyCustomerId")]
        [HttpGet]
        public async Task<ActionResult<Favorite>> getfavoritesbycustomerid(int id)
        {
            var favorite = _context.Favorites.Where(e => e.CustomerId==id).ToList();

            //if (favorite == null)
            //{
            //    return NotFound();
            //}

            return Ok(favorite);
        }

        //SaveFavorites Method
        [HttpPost]
        [Route("SaveFavorites")]
        public async Task<IActionResult> SaveFavorites(int customerid, int productid)
        {
            var customer = await _context.Customers.FindAsync(customerid);
            var product = await _context.Products.FindAsync(productid);
            if(customer == null || product == null)
            {
                return NotFound();
            }

            var savefav=new Favorite
            {
                CustomerId = customerid,
                ProductId = productid,
                ActiveStatus = true,
                Product = product,
                Customer = customer
            };

            _context.Favorites.Add(savefav);
            await _context.SaveChangesAsync();

            return Ok();


        }


        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.FavoritesId == id);
        }
    }
}



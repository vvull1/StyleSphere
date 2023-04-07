using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
using StyleSphere.ViewModels;

namespace StyleSphere.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly StyleSphereDbContext _context;

        public CategoryService(StyleSphereDbContext context)
        {
            _context = context;
        }
        public Category getCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        
        public async Task<IActionResult> getallCategories()
        {
            var categories = await _context.Categories
                  .Select(item => new CategoryViewModel
                  {
                      CategoryId = item.CategoryId,
                      CategoryName = item.CategoryName,
                      Description = item.Description,
                      ShowOnTop = item.ShowOnTop
                  })
                  .ToListAsync();
            return new OkObjectResult(categories);
        }
    }
}

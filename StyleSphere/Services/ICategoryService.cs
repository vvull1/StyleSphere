using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Services
{
    public interface ICategoryService
    {
        public Category getCategory(int id);

        public Task<IActionResult> getallCategories();
    }
}

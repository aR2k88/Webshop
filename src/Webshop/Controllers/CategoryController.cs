using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using Webshop.Services;

namespace Webshop.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<Category> CreateCategory(string categoryName)
        {
            var result = await _categoryService.CreateCategory(categoryName);
            return result;
        }
    }
}
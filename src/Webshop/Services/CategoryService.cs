using System.Threading.Tasks;
using Webshop.DataProviders;
using Webshop.Models;

namespace Webshop.Services
{
    public interface ICategoryService
    {
        public Task<Category> CreateCategory(string categoryName);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDataProvider _categoryDataProvider;

        public CategoryService(ICategoryDataProvider categoryDataProvider)
        {
            _categoryDataProvider = categoryDataProvider;
        }
        public async Task<Category> CreateCategory(string categoryName)
        {
            var newCat = new Category(categoryName);
            var res = await _categoryDataProvider.Create(newCat);
            return res;
        }
    }
}
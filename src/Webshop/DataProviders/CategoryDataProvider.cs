using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Webshop.Models;

namespace Webshop.DataProviders
{
    public interface ICategoryDataProvider
    {
        public Task<Category> Create(Category category);
        public Task<Category> Update(Category category);
        public Task<Category> Delete(Category category);
        public Task<Category> Get(string categoryName);
        public Task<IEnumerable<Category>> GetAllCategories();
    }

    public class CategoryDataProvider : ICategoryDataProvider
    {
        private readonly IMongoCollection<Category> _collection;
        public CategoryDataProvider(IMongoDatabase database)
        {
            _collection = database.GetCollection<Category>("Category");
        }
        public async Task<Category> Create(Category category)
        {
            await _collection.InsertOneAsync(category);
            return category;
        }

        public Task<Category> Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> Delete(Category category)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> Get(string categoryName)
        {
            var res = await _collection.FindAsync(x => x.CategoryName == categoryName);
            return res.FirstOrDefault();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        
    }
}
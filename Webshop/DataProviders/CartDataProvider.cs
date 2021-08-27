using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.DataProviders
{
    public class CartDataProvider : ICartDataProvider
    {
        private readonly IMongoCollection<Cart> _collection;
        public CartDataProvider(IMongoDatabase database)
        {
            _collection = database.GetCollection<Cart>("Cart");
        }

        public async Task<Cart> Create(Cart cart)
        {
            await _collection.InsertOneAsync(cart);
            return cart;
        }

        public async Task<Cart> Save(Cart cart)
        {
             await _collection.ReplaceOneAsync(x => x._id == cart._id, cart);
             return await Get(cart._id);
        }


        public async Task<Cart> Get(Guid cartId)
        {
            return await _collection.Find(x => x._id == cartId).SingleOrDefaultAsync();
        }
    }
}
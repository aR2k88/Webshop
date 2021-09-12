using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Webshop.DataProviders
{
    public class UserDataProvider
    {
        private readonly IMongoCollection<User> _collection;
        public UserDataProvider(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("User");
        }

        public async Task<User> VerifyUser(string username, string password)
        {
            var res = await _collection.Find(x => x.Username == username && x.Password == password).SingleOrDefaultAsync();
            return res;
        }

        public async Task CreateUser()
        {
            var user = new User();
            user.Password = "test123";
            user.Username = "Admin";
            await _collection.InsertOneAsync(user);
        }
    }

    public class User
    {
        [BsonId]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
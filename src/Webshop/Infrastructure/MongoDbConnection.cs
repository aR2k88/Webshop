using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Webshop.Infrastructure
{
    public class MongoDbConnection
    {
        static MongoDbConnection()
        {
            BsonSerializer.RegisterSerializer(typeof(DateTimeOffset), new DateTimeOffsetSerializer(BsonType.String));
            ConventionRegistry.Register("EnumStringConvention", new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            }, t => true);
        }

        public static IMongoDatabase ConnectToMongoDb(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            CreateIndexes(database);
            return database;
        }

        private static void CreateIndexes(IMongoDatabase database)
        {
            
        }
    }
}
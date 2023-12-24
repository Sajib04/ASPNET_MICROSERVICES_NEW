using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        // creating mongo context
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration
                .GetValue<string>("DatabaseSettings:CollectionName"));

            // for seed data
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }

        
    }
}

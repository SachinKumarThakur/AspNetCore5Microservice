
namespace Catalog.API.Data
{
    using Catalog.API.Entities;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using System;
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSetting:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));
            Products = database.GetCollection<Products>(configuration.GetValue<string>("DatabaseSetting:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Products> Products { get; }

    }
}

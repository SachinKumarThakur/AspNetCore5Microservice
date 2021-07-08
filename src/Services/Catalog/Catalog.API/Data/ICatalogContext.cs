namespace Catalog.API.Data
{
    using MongoDB.Driver;
    using Catalog.API.Entities;
 
    public interface ICatalogContext
    {
        public IMongoCollection<Products> Products { get;  }
    }
}

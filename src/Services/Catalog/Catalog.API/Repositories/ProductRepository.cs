
namespace Catalog.API.Repositories
{
    using Catalog.API.Data;
    using Catalog.API.Entities;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public Task CreateProductAsync(Products product)
        {
            return _catalogContext
                        .Products
                        .InsertOneAsync(product);
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            FilterDefinition<Products> filterDefinition = Builders<Products>.Filter.ElemMatch(p => p.Id, productId);

            var deleteresult = await _catalogContext
                                             .Products
                                             .DeleteOneAsync(filterDefinition);
            return deleteresult.IsAcknowledged
                                && deleteresult.DeletedCount > 0;
        }

        public async Task<Products> GetByIdAsync(string id)
        {
            
            return await _catalogContext
                            .Products
                            .Find(p=>p.Id==id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await _catalogContext
                            .Products
                            .Find(p=>true)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsByCategory(string category)
        {
            FilterDefinition<Products> filterDefinition = Builders<Products>.Filter.ElemMatch(p=> p.Category,category);
            return await _catalogContext
                            .Products
                            .Find(filterDefinition)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsByNameAsync(string name)
        {
            FilterDefinition<Products> filterDefinition = Builders<Products>.Filter.ElemMatch(p => p.Name, name);
            return await _catalogContext
                            .Products
                            .Find(filterDefinition)
                            .ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Products product)
        {
           var updatedresult=  await _catalogContext
                                             .Products
                                             .ReplaceOneAsync(filter: g=>g.Id == product.Id, replacement:product);
            return updatedresult.IsAcknowledged
                                && updatedresult.ModifiedCount > 0;

        }
    }
}

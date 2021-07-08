
namespace Catalog.API.Repositories
{
    using Catalog.API.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository
    {

        Task<Products> GetByIdAsync(string id);
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<IEnumerable<Products>> GetProductsByNameAsync(string name);
        Task<IEnumerable<Products>> GetProductsByCategory(string category);

        Task CreateProductAsync(Products product);
        Task<bool> DeleteProductAsync(string productId);
        Task<bool> UpdateProductAsync(Products product);




    }
}



namespace Basket.API.Repositories.Interfaces
{
    using Basket.API.Entities;
    using System.Threading.Tasks;
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}

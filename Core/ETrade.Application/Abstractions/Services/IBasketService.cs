using ETrade.Application.ViewModels.Baskets;
using ETrade.Domain.Entities;

namespace ETrade.Application.Abstractions.Services;

public interface IBasketService
{
    public Task<List<BasketItem>> GetBasketItemsAsync();
    public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
    public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
    public Task RemoveBasketItemAsync(string basketItemId);
    public Basket? GetUserActiveBasket { get; }
}

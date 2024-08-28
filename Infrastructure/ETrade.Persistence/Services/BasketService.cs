using ETrade.Application.Abstractions.Services;
using ETrade.Application.Repositories.BasketItemRepository;
using ETrade.Application.Repositories.BasketRepository;
using ETrade.Application.Repositories.OrderRepository;
using ETrade.Application.ViewModels.Baskets;
using ETrade.Domain.Entities;
using ETrade.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Persistence.Services;

public class BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository) : IBasketService
{
    readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    readonly UserManager<AppUser> _userManager = userManager;
    readonly IOrderReadRepository _orderReadRepository = orderReadRepository;
    readonly IBasketWriteRepository _basketWriteRepository = basketWriteRepository;
    readonly IBasketReadRepository _basketReadRepository = basketReadRepository;
    readonly IBasketItemWriteRepository _basketItemWriteRepository = basketItemWriteRepository;
    readonly IBasketItemReadRepository _basketItemReadRepository = basketItemReadRepository;

    private async Task<Basket?> ContextUser()
    {
        var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
        if (!string.IsNullOrEmpty(username))
        {
            AppUser? user = await _userManager.Users
                     .Include(u => u.Baskets)
                     .FirstOrDefaultAsync(u => u.UserName == username);

            var _basket = from basket in user.Baskets
                          join order in _orderReadRepository.Table
                          on basket.Id equals order.Id into BasketOrders
                          from order in BasketOrders.DefaultIfEmpty()
                          select new
                          {
                              Basket = basket,
                              Order = order
                          };

            Basket? targetBasket = null;
            if (_basket.Any(b => b.Order is null))
                targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
            else
            {
                targetBasket = new();
                user.Baskets.Add(targetBasket);
            }

            await _basketWriteRepository.SaveAsync();
            return targetBasket;
        }
        throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
    }

    public async Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
    {
        Basket? basket = await ContextUser();
        if (basket != null)
        {
            BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId));
            if (_basketItem != null)
                _basketItem.Quantity++;
            else
                await _basketItemWriteRepository.AddAsync(new()
                {
                    BasketId = basket.Id,
                    ProductId = Guid.Parse(basketItem.ProductId),
                    Quantity = basketItem.Quantity
                });

            await _basketItemWriteRepository.SaveAsync();
        }
    }

    public async Task<List<BasketItem>> GetBasketItemsAsync()
    {
        Basket? basket = await ContextUser();
        Basket? result = await _basketReadRepository.Table
             .Include(b => b.BasketItems)
             .ThenInclude(bi => bi.Product)
             .FirstOrDefaultAsync(b => b.Id == basket.Id);

        return result.BasketItems
            .ToList();
    }

    public async Task RemoveBasketItemAsync(string basketItemId)
    {
        BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
        if (basketItem != null)
        {
            _basketItemWriteRepository.Remove(basketItem);
            await _basketItemWriteRepository.SaveAsync();
        }
    }

    public async Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
    {
        BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
        if (_basketItem != null)
        {
            _basketItem.Quantity = basketItem.Quantity;
            await _basketItemWriteRepository.SaveAsync();
        }
    }

    public Basket? GetUserActiveBasket
    {
        get
        {
            Basket? basket = ContextUser().Result;
            return basket;
        }
    }
}

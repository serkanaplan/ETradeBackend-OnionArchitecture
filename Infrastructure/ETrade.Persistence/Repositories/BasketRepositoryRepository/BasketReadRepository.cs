using ETrade.Application.Repositories.BasketRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.BasketRepositoryRepository;

public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
{
    public BasketReadRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

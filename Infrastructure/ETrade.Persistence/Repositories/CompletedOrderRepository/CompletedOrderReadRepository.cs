using ETrade.Application.Repositories.CompletedOrderRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.CompletedOrderRepository;

public class CompletedOrderReadRepository : ReadRepository<CompletedOrder>, ICompletedOrderReadRepository
{
    public CompletedOrderReadRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

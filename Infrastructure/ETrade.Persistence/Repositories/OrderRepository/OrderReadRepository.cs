using ETrade.Application.Repositories.OrderRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.OrderRepository;

public class OrderReadRepository(ETradeAPIDBContext context) : ReadRepository<Order>(context), IOrderReadRepository
{
}

using ETrade.Application.Repositories.BaseRepository;
using ETrade.Domain.Entities;

namespace ETrade.Application.Repositories.OrderRepository;

public interface IOrderWriteRepository : IWriteRepository<Order>
{
}

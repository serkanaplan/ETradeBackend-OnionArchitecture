using ETrade.Application.Repositories.BaseRepository;
using ETrade.Domain.Entities;

namespace ETrade.Application.Repositories.CompletedOrderRepository;

public interface ICompletedOrderReadRepository : IReadRepository<CompletedOrder>
{
}

using ETrade.Persistence.Repositories.BaseRepository;
using ETrade.Application.Repositories.MenuRepository;
using ETrade.Persistence.Contexts;
using ETrade.Domain.Entities;

namespace ETrade.Persistence.Repositories.MenuRepository;

public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
{
    public MenuReadRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

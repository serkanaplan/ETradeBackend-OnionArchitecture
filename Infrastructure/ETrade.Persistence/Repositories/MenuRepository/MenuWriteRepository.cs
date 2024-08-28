using ETrade.Application.Repositories.MenuRepository;
using ETrade.Persistence.Repositories.BaseRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;

namespace ETrade.Persistence.Repositories.MenuRepository;

public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
{
    public MenuWriteRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

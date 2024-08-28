using ETrade.Application.Repositories.FileRepository;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.FileRepository;

public class FileReadRepository : ReadRepository<Domain.Entities.File>, IFileReadRepository
{
    public FileReadRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

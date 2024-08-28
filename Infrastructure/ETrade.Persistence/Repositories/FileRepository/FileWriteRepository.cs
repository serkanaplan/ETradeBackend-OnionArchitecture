using ETrade.Application.Repositories.FileRepository;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.FileRepository;

public class FileWriteRepository : WriteRepository<Domain.Entities.File>, IFileWriteRepository
{
    public FileWriteRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

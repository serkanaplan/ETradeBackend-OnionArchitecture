using ETrade.Application.Repositories.BaseRepository;
using F = ETrade.Domain.Entities;

namespace ETrade.Application.Repositories.FileRepository;

// public interface IFileWriteRepository : IWriteRepository<Domain.Entities.File>
public interface IFileWriteRepository : IWriteRepository<F.File>// veya <F::File>
{
}

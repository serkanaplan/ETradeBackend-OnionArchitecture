using ETrade.Application.Repositories.BaseRepository;
using ETrade.Domain.Entities;

namespace ETrade.Application.Repositories.ProductRepository;

public interface IProductWriteRepository : IWriteRepository<Product>
{
}

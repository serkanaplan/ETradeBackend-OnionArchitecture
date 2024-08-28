using ETrade.Application.Repositories.ProductRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.ProductRepository;

public class ProductReadRepository(ETradeAPIDBContext context) : ReadRepository<Product>(context), IProductReadRepository
{
}

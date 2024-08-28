using ETrade.Application.Repositories.ProductImageFileRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.ProductImageFileRepository;

public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

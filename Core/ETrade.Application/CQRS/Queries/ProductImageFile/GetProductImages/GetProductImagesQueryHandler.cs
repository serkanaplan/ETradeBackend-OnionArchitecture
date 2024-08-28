using ETrade.Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ETrade.Application.CQRS.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration) : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
{
    readonly IProductReadRepository _productReadRepository = productReadRepository;
    readonly IConfiguration configuration = configuration;

    public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
               .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
        return product?.ProductImageFiles.Select(p => new GetProductImagesQueryResponse
        {
            Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
            FileName = p.FileName,
            Id = p.Id
        }).ToList();
    }
}

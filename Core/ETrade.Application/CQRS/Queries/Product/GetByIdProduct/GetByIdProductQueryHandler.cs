using ETrade.Application.Repositories.ProductRepository;
using MediatR;
using P = ETrade.Domain.Entities;

namespace ETrade.Application.CQRS.Queries.Product.GetByIdProduct;

internal class GetByIdProductQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
{
    readonly IProductReadRepository _productReadRepository = productReadRepository;

    public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
        P.Product product = await _productReadRepository.GetByIdAsync(request.Id, false);
        return new()
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}

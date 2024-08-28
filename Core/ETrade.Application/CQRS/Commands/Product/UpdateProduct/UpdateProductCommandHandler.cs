using ETrade.Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ETrade.Application.CQRS.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<UpdateProductCommandHandler> logger) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    readonly IProductReadRepository _productReadRepository = productReadRepository;
    readonly IProductWriteRepository _productWriteRepository = productWriteRepository;
    readonly ILogger<UpdateProductCommandHandler> _logger = logger;

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
        product.Stock = request.Stock;
        product.Name = request.Name;
        product.Price = request.Price;
        await _productWriteRepository.SaveAsync();
        _logger.LogInformation("Product güncellendi...");
        return new();
    }
}

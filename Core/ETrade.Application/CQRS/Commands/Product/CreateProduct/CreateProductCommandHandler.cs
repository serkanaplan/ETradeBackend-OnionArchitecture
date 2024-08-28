using ETrade.Application.Abstractions.Hubs;
using ETrade.Application.Repositories.ProductRepository;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Product.CreateProduct;

public class CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductHubService productHubService) : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    readonly IProductWriteRepository _productWriteRepository = productWriteRepository;
    readonly IProductHubService _productHubService = productHubService;

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        });
        await _productWriteRepository.SaveAsync();
        await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir.");
        return new();
    }
}
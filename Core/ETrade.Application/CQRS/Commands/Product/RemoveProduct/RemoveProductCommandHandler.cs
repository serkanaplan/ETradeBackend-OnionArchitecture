using ETrade.Application.Repositories.ProductRepository;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Product.RemoveProduct;

public class RemoveProductCommandHandler(IProductWriteRepository productWriteRepository) : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
{
    readonly IProductWriteRepository _productWriteRepository = productWriteRepository;

    public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return new();
    }
}

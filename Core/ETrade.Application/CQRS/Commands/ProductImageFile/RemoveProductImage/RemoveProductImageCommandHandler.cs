using ETrade.Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Application.CQRS.Commands.ProductImageFile.RemoveProductImage;

public class RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository) : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
{

    readonly IProductReadRepository _productReadRepository = productReadRepository;
    readonly IProductWriteRepository _productWriteRepository = productWriteRepository;

    public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

        Domain.Entities.ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

        if (productImageFile != null)
            product?.ProductImageFiles.Remove(productImageFile);

        await _productWriteRepository.SaveAsync();
        return new();
    }
}

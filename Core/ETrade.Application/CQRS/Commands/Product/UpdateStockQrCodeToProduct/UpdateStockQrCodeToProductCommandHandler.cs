using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Product.UpdateStockQrCodeToProduct;

public class UpdateStockQrCodeToProductCommandHandler(IProductService productService) : IRequestHandler<UpdateStockQrCodeToProductCommandRequest, UpdateStockQrCodeToProductCommandResponse>
{
    readonly IProductService _productService = productService;

    public async Task<UpdateStockQrCodeToProductCommandResponse> Handle(UpdateStockQrCodeToProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productService.StockUpdateToProductAsync(request.ProductId, request.Stock);
        return new();
    }
}

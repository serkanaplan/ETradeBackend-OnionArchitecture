using System.Text.Json;
using ETrade.Application.Abstractions.Services;
using ETrade.Application.Repositories.ProductRepository;
using ETrade.Domain.Entities;

namespace ETrade.Persistence.Services;

public class ProductService(IProductReadRepository productReadRepository, IQRCodeService qrCodeService, IProductWriteRepository productWriteRepository) : IProductService
{
    readonly IProductReadRepository _productReadRepository = productReadRepository;
    readonly IProductWriteRepository _productWriteRepository = productWriteRepository;
    readonly IQRCodeService _qrCodeService = qrCodeService;

    public async Task<byte[]> QrCodeToProductAsync(string productId)
    {
        Product product = await _productReadRepository.GetByIdAsync(productId) ?? throw new Exception("Product not found");
        var plainObject = new
        {
            product.Id,
            product.Name,
            product.Price,
            product.Stock,
            product.CreatedDate
        };
        string plainText = JsonSerializer.Serialize(plainObject);

        return _qrCodeService.GenerateQRCode(plainText);
    }

    public async Task StockUpdateToProductAsync(string productId, int stock)
    {
        Product product = await _productReadRepository.GetByIdAsync(productId) ?? throw new Exception("Product not found");
        product.Stock = stock;
        await _productWriteRepository.SaveAsync();
    }
}

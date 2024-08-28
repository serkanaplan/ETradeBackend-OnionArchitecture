using ETrade.Application.Abstractions.Storage;
using ETrade.Application.Repositories.ProductImageFileRepository;
using ETrade.Application.Repositories.ProductRepository;
using MediatR;

namespace ETrade.Application.CQRS.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository) : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
{
    readonly IStorageService _storageService = storageService;
    readonly IProductReadRepository _productReadRepository = productReadRepository;
    readonly IProductImageFileWriteRepository _productImageFileWriteRepository = productImageFileWriteRepository;

    public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

        Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);

        await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProductImageFile
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Products = new List<Domain.Entities.Product>() { product }
        }).ToList());

        await _productImageFileWriteRepository.SaveAsync();

        return new();
    }
}

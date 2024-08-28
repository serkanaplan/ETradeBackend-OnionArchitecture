using ETrade.Application.Repositories.ProductImageFileRepository;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Application.CQRS.Commands.ProductImageFile.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository) : MediatR.IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
{
    readonly IProductImageFileWriteRepository _productImageFileWriteRepository = productImageFileWriteRepository;

    public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
    {
        var query = _productImageFileWriteRepository.Table.Include(p => p.Products).SelectMany(p => p.Products, (pif, p) => new{ pif,p });

        var data = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.Showcase);

        if (data != null) data.pif.Showcase = false;

        var image = await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
        
        if (image != null) image.pif.Showcase = true;

        await _productImageFileWriteRepository.SaveAsync();
        
        return new();
    }
}

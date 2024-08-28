using MediatR;

namespace ETrade.Application.CQRS.Commands.ProductImageFile.RemoveProductImage;

public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
{
    public string Id { get; set; }
    public string? ImageId { get; set; }
}

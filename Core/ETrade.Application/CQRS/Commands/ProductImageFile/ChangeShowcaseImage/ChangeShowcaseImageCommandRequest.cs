using MediatR;

namespace ETrade.Application.CQRS.Commands.ProductImageFile.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
{
    public string ImageId { get; set; }
    public string ProductId { get; set; }
}

using MediatR;

namespace ETrade.Application.CQRS.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
{
    public string Id { get; set; }
}

namespace ETrade.Application.CQRS.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryResponse
{
    public string Path { get; set; }
    public string FileName { get; set; }
    public Guid Id { get; set; }
}

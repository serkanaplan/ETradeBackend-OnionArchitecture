namespace ETrade.Application.CQRS.Queries.Product.GetAllProduct;

public class GetAllProductQueryResponse
{
    public int TotalProductCount { get; set; }
    public object Products { get; set; }
}
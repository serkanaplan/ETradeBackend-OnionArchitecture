namespace ETrade.Application.CQRS.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryResponse
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}

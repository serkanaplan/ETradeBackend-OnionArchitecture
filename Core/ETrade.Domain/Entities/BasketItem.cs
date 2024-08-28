using ETrade.Domain.Entities.Common;

namespace ETrade.Domain.Entities;

public class BasketItem : BaseEntity
{
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Basket Basket { get; set; }
    public Product Product { get; set; }
}

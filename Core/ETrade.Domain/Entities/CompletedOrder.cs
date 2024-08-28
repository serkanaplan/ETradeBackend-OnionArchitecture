using ETrade.Domain.Entities.Common;

namespace ETrade.Domain.Entities;

public class CompletedOrder : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}

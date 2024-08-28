using ETrade.Domain.Entities.Common;
using ETrade.Domain.Entities.Identity;

namespace ETrade.Domain.Entities;

public class Basket : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public Order Order { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
}

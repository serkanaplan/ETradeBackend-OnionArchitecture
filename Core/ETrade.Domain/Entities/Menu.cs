using ETrade.Domain.Entities.Common;

namespace ETrade.Domain.Entities;

public class Menu : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Endpoint> Endpoints { get; set; }
}

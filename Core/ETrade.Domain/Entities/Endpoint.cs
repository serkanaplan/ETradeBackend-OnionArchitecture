using ETrade.Domain.Entities.Common;
using ETrade.Domain.Entities.Identity;

namespace ETrade.Domain.Entities;

public class Endpoint : BaseEntity
{
    public Endpoint() => Roles = [];
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }

    public Menu Menu { get; set; }
    public ICollection<AppRole> Roles { get; set; }
}


//{ "actionType":"Updating","httpType":"PUT","definition":"Update Role","code":"PUT.Updating.UpdateRole"}
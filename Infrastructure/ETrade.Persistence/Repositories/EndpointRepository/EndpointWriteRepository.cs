using ETrade.Application.Repositories.EndpointRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.EndpointRepository;

public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
{
    public EndpointWriteRepository(ETradeAPIDBContext context) : base(context)
    {
    }
}

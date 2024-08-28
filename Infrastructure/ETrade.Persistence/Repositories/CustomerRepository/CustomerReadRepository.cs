using ETrade.Application.Repositories.CustomerRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.CustomerRepository;

public class CustomerReadRepository(ETradeAPIDBContext context) : ReadRepository<Customer>(context), ICustomerReadRepository
{
}

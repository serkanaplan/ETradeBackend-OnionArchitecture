using ETrade.Application.Repositories.CustomerRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.BaseRepository;

namespace ETrade.Persistence.Repositories.CustomerRepository;

public class CustomerWriteRepository(ETradeAPIDBContext context) : WriteRepository<Customer>(context), ICustomerWriteRepository
{
}

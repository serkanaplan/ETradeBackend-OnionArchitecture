using ETrade.Application.Repositories.BaseRepository;
using ETrade.Domain.Entities;

namespace ETrade.Application.Repositories.CustomerRepository;

public interface ICustomerWriteRepository : IWriteRepository<Customer>
{
}

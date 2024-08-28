using ETrade.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Application.Repositories.BaseRepository;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}

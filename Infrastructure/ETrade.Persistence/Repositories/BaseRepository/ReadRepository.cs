using ETrade.Application.Repositories.BaseRepository;
using ETrade.Domain.Entities.Common;
using ETrade.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETrade.Persistence.Repositories.BaseRepository;

public class ReadRepository<T>(ETradeAPIDBContext context) : IReadRepository<T> where T : BaseEntity
{
    private readonly ETradeAPIDBContext _context = context;
    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        return tracking ? Table : Table.AsNoTracking();
    }


    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        return tracking ? Table.Where(method) : Table.Where(method).AsNoTracking();
    }


    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        return await (tracking ? Table : Table.AsNoTracking()).FirstOrDefaultAsync(method);
    }


    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        return await (tracking ? Table : Table.AsNoTracking()).FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }


}
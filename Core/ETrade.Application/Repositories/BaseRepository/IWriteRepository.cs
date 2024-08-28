using ETrade.Domain.Entities.Common;

namespace ETrade.Application.Repositories.BaseRepository;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> datas);
    bool Remove(T model);
    bool RemoveRange(List<T> datas);
    Task<bool> RemoveAsync(string id);
    bool Update(T model);
    Task<int> SaveAsync();
}

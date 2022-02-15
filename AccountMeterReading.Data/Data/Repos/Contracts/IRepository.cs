using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMeterReading.Data.Data.Repos.Contracts
{
    public interface IRepository<TEntity, in TPrimaryKeyType> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(TPrimaryKeyType id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Count();
    }
}

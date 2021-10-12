using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teaching.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetEntityList();
        Task<TEntity> GetEntityById(Guid? id);
        Task Create(TEntity item);
        Task Update(TEntity item);
        Task Delete(Guid? id);
    }
}

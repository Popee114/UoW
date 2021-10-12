using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teaching.DbContexts;
using Teaching.Models.Interfaces;
using Teaching.Repositories.Interfaces;

namespace Teaching.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : Identificator
    {
        internal AccountContext _accountContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(AccountContext accountContext)
        {
            _accountContext = accountContext;
            _dbSet = accountContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            if (entity == null)
                throw new Exception($"Сущность {nameof(entity)} пуста.");
            _dbSet.Add(entity);
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null)
                throw new Exception($"Сущность {nameof(entity)} пуста.");
            _dbSet.Update(entity);
        }

        public async Task Delete(Guid? id)
        {
            if (id == null)
                throw new Exception("Идентификатор пуст.");
            var user = await GetEntityById(id);
            _dbSet.Remove(user);
        }

        public async Task<TEntity> GetEntityById(Guid? id)
        {
            if (id == null)
                throw new Exception("Идентификатор пуст.");

            var user = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new Exception("Пользователь пуст.");

            return user;
        }

        public async Task<List<TEntity>> GetEntityList()
        {
            var entity = await _dbSet.ToListAsync();

            if (entity == null)
                throw new Exception("Список пользователей пуст.");

            return entity;
        }
    }
}

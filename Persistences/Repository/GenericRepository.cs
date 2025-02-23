using Microsoft.EntityFrameworkCore;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>  where T : class
    {
        protected readonly FunewsManagementContext _context;
        private DbSet<T> _dbSet;
        protected GenericRepository(FunewsManagementContext funewsManagementContext)
        {
            if(_context == null)
            {
                _context = funewsManagementContext;               
            }
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetBySingleAsync(Expression<Func<T, bool>> predicate)
        {

            return await _dbSet.Where<T>(predicate).SingleOrDefaultAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}

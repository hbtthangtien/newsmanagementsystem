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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FunewsManagementContext _context;
        private DbSet<T> _dbSet;
        protected GenericRepository(FunewsManagementContext funewsManagementContext)
        {
            _context = funewsManagementContext;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}

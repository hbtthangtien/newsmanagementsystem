using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);

        public Task<IEnumerable<T>> GetAllAsync();

        public Task AddAsync(T entity);

        public void Update(T entity);
    }
}

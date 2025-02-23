using Persistences.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICategoryServices
    {
        public Task<IEnumerable> GetAllCategoryAsync();

        public Task DeleteCategoryById(int id);

        public Task<Category> GetCategoryById(int id);

        public Task UpdateCategory(Category category);

        public Task AddCategoryAsync(Category category);
    }
}

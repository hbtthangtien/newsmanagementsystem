using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryrepository
    {
        public CategoryRepository(FunewsManagementContext funewsManagementContext) 
            : base(funewsManagementContext)
        {
        }
    }
}

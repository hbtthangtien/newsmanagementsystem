using Persistences.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface INewArticleService
    {
        public Task<IEnumerable> GetAllAsync();

        public Task<NewsArticle> GetByIdAsync(string id);
    }
}

using Persistences.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Interface
{
    public interface INewArticleRepository : IGenericRepository<NewsArticle>
    {
        public Task AddNewsArticle(NewsArticle newNewsArticle, string[] tagId);

        public Task UpdateArticle(NewsArticle article, string[] tagId);

        public Task<IEnumerable> GetAllByCreatedId(string createdId);
    }
}

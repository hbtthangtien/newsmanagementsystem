using Application.Interface;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NewArticleService : INewArticleService
    {
        private readonly INewArticleRepository _newArticleRepository;
        public NewArticleService(INewArticleRepository newArticleRepository)
        {
            _newArticleRepository = newArticleRepository;
        }
        public async Task<IEnumerable> GetAllAsync()
        {
            return await _newArticleRepository.GetAllAsync();
        }

        public async Task<NewsArticle> GetByIdAsync(string id)
        {
            return await _newArticleRepository.GetBySingleAsync(u => u.NewsArticleId == id);
        }
    }
}

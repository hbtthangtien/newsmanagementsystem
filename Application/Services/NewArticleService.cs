using Application.DTOs;
using Application.Interface;
using Microsoft.EntityFrameworkCore;
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
        private readonly ITagRepository _tagRepository;
        public NewArticleService(INewArticleRepository newArticleRepository, ITagRepository tagRepository)
        {
            _newArticleRepository = newArticleRepository;
            _tagRepository = tagRepository;
        }

        public async Task AddAsync(NewsArticleDTO dto)
        {

            string[] tagId = dto.Tags!.Split(";");

            var article = new NewsArticle
            {
                CategoryId = short.Parse(dto.Category!),
                NewsArticleId = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                NewsStatus = false,
                Headline = dto.Headline!,
                NewsContent = dto.NewsContent,
                NewsTitle = dto.NewsTitle,
                NewsSource = dto.NewsSource,
                CreatedById = short.Parse(dto.CreatedBy!),
            };
            await _newArticleRepository.AddNewsArticle(article, tagId);
        }

        public async Task DeleteAsync(string id)
        {
            var news = await _newArticleRepository.GetBySingleAsync(e => e.NewsArticleId == id);
            await _newArticleRepository.DeleteAsync(news);
            await _newArticleRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            return await _newArticleRepository.GetAllAsync();
        }

        public async Task<IEnumerable> GetAllByCreatedById(string id)
        {
            var data = await _newArticleRepository.GetAllByCreatedId(id);
            return data;
        }

        public async Task<NewsArticle?> GetByIdAsync(string id)
        {
            return await _newArticleRepository.GetBySingleAsync(u => u.NewsArticleId == id);
        }

        public async Task UpdateAsync(NewsArticleDTO dto)
        {
            string[] tagId = dto.Tags!.Split(";");
            var news =await _newArticleRepository.GetBySingleAsync(e => e.NewsArticleId == dto.NewsArticleId);
            news!.NewsStatus = dto.NewsStatus;
            news!.NewsTitle = dto.NewsTitle;
            news.NewsContent = dto.NewsContent;
            news.NewsSource = dto.NewsSource;
            news.Headline = dto.Headline!;
            news.UpdatedById = short.Parse(dto.UpdatedBy!);
            news.CategoryId = short.Parse(dto.Category!);
            news.ModifiedDate = DateTime.Now;
            await _newArticleRepository.UpdateArticle(news,tagId);
        }
    }
}

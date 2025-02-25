using Microsoft.EntityFrameworkCore;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Repository
{
    public class NewArticleRepository : GenericRepository<NewsArticle>, INewArticleRepository
    {
        public NewArticleRepository(FunewsManagementContext funewsManagementContext) : base(funewsManagementContext)
        {
        }

        public async Task AddNewsArticle(NewsArticle newNewsArticle, string[] tagId)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var item in tagId)
            {
                try
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == int.Parse(item));
                    tags.Add(tag);
                }
                catch (Exception ex)
                {

                }
            }
            newNewsArticle.Tags = tags;
            try
            {
                await _context.NewsArticles.AddAsync(newNewsArticle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IEnumerable> GetAllByCreatedId(string createdId)
        {
            var list = await _context.NewsArticles.Where(e => e.CreatedById == short.Parse(createdId)).ToListAsync();
            return list;
        }

        public async Task UpdateArticle(NewsArticle newNewsArticle, string[] tagId)
        {
            List<Tag> tags = new List<Tag>();
            var article = await _context.NewsArticles.Include(e => e.Tags)
                .FirstOrDefaultAsync(e => e.NewsArticleId == newNewsArticle.NewsArticleId);
            article!.Tags.Clear();
            foreach (var item in tagId)
            {
                try
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagId == int.Parse(item));
                    if(tag != null) tags.Add(tag);
                }
                catch (Exception ex)
                {

                }
            }
            article.Tags = tags;
            article.NewsStatus = newNewsArticle.NewsStatus;
            article.NewsSource = newNewsArticle.NewsSource;
            article.CategoryId = newNewsArticle.CategoryId;
            article.UpdatedById = newNewsArticle.UpdatedById;
            article.CreatedDate = newNewsArticle.CreatedDate;
            article.CreatedById = newNewsArticle.CreatedById;
            article.NewsContent = newNewsArticle.NewsContent;
            article.NewsTitle = newNewsArticle.NewsTitle;
            article.Headline = newNewsArticle.Headline;
            article.ModifiedDate = newNewsArticle.ModifiedDate;
            await _context.SaveChangesAsync();
        }
    }
}

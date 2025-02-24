using Microsoft.EntityFrameworkCore;
using Persistences.Entities;
using Persistences.Interface;
using System;
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
    }
}

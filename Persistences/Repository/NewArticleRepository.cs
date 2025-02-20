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
    }
}

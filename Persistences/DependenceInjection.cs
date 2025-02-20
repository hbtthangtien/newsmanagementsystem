using Microsoft.Extensions.DependencyInjection;
using Persistences.Interface;
using Persistences.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences
{
    public static class DependenceInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<ICategoryrepository,CategoryRepository>();
            services.AddScoped<INewArticleRepository,NewArticleRepository>();
            services.AddScoped<ISystemAccount,SystemAccountRepository>();
            services.AddScoped<ITagRepository,TagRepository>();
        }
    }
}

using Application.Interface;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticateService,AuthenticateService>();
            services.AddScoped<INewArticleService,NewArticleService>();
            services.AddScoped<ICategoryServices,CategoryService>();
            services.AddScoped<ITagService,TagService>();
            services.AddScoped<IAccountService,AccountService>();
        }
    }
}

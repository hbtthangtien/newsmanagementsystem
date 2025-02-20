using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistences.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.DatabaseConfig
{
    public static class DatabaseConfig
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FunewsManagementContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FUNewsManagement"));
            });
        }
    }
}

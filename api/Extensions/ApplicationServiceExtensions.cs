using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Repository;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
   public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
                services.AddDbContext<DataContext>(options => 
                {
                    options.UseSqlServer(config.GetConnectionString("Movies"));
                });
                services.AddScoped<IMovieRepository, MovieRepository>();
                return services;
        }
    }
}
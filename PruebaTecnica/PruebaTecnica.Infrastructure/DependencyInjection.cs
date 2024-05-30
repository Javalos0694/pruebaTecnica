using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Infrastructure.Data;
using PruebaTecnica.Infrastructure.Repositories;
using PruebaTecnica.Infrastructure.Repositories.Interfaces;

namespace PruebaTecnica.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PruebaContext>(option => option.UseSqlServer(configuration.GetConnectionString("PruebaEntities")));

            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;

        }
    }
}

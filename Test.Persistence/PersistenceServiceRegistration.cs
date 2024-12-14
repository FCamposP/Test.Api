using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts;
using Test.Persistence.Repositories;

namespace Test.Persistence
{
    public static class PersistenceServiceRegistration
    {
        /// <summary>
        /// Metodo utilizado para inyeccion de dependencias 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IQueryManager<>), typeof(QueryManager<>));
            services.AddScoped(typeof(IApplicationDbContext), typeof(ApplicationDbContext));
            return services;
        }
    }
}

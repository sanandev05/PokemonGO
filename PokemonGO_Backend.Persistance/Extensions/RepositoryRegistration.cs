using Microsoft.Extensions.DependencyInjection;
using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;
using PokemonGO_Backend.Persistance.Repositories;

namespace PokemonGO_Backend.Persistance.Extensions
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddSingleton<IGenericRepository<LogData>, GenericRepository<LogData>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

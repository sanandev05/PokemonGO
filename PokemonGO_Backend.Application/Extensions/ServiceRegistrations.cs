using Microsoft.Extensions.DependencyInjection;
using PokemonGO_Backend.Application.Services;
using PokemonGO_Backend.Contract.Services;

namespace PokemonGO_Backend.Application.Extensions
{
    public static class ServiceRegistrations 
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<,>),typeof(GenericService<,>));
            return services;
        }
    }
}

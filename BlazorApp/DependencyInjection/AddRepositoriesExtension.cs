using Application.Abstractions.Repositories;
using Repositories;

namespace BlazorApp.DependencyInjection
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddRepositories(
           this IServiceCollection services)
        {
            services.AddTransient<IProvaRepository, ProvaRepository>();
            services.AddTransient<IStrategyRepository, StrategyRepository>();

            return services;
        }
    }
}

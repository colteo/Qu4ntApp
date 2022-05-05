using Repositories.Context;
using Repositories.MongoDB;

namespace RestAPI.DependencyInjection
{
    public static class MongoDbInfrastructureExtension
    {
        public static IServiceCollection AddMongoDbPersistence(
          this IServiceCollection services,
          IConfiguration configuration)
        {

            var config = new ServerConfig();
            configuration.Bind(config);

            services.AddTransient<StrategyDbContext>(s => new StrategyDbContext(config.MongoDB));
            services.AddTransient<ProvaDbContext>(s => new ProvaDbContext(config.MongoDB));
            ;
            return services;
        }
    }
}

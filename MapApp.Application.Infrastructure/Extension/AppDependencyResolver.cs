using MapApp.Application.Contracts.Persistence.Query;
using MapApp.Dapper;
using MapApp.Domain.Config;
using MapApp.Infrastructure.Persistence.Query;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppDependencyResolver
    {
        public static void ConfigureAddressMapServices(this IServiceCollection services, IConfiguration configuration) {
            ConnectionStringsConfig connectionString = new ConnectionStringsConfig();
            configuration.GetSection("ConnectionStringsConfig").Bind(connectionString);
            services.AddSingleton(connectionString);

            services.AddSingleton<ISQLDapperBase, SQLDapperBase>();
            services.AddScoped<IAddressMapQueryService, AddressMapQueryService>();
        }
    }
}

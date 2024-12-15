using ExemploDDD.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploDDD.Infraestructure;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LocalHost");

        services.AddDbContext<ExemploDDDDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }
}


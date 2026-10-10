using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmniReserve.Application.Common.Interfaces;
using OmniReserve.Infrastructure.Persistence;
using OmniReserve.Infrastructure.Persistence.Repositories;

namespace OmniReserve.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Registro del DbContext utilizando PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("OmniReserveDb")));

        // Repositorio
        services.AddScoped<IRoomRepository, RoomRepository>();

        return services;
    }
}

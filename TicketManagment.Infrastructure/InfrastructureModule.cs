using Microsoft.Extensions.DependencyInjection;
using TicketManagment.Application;

namespace TicketManagment.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
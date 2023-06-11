using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TicketManagment.Application.Profiles;
using TicketManagment.Application.Services.Ticket;

namespace TicketManagment.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfiles(MapperProfiles.GetAssemblyProfiles());
        }).CreateMapper());
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddTransient<ITicketService, TicketService>();
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using TicketManagment.Infrastructure.DbContexts;

namespace TicketManagment.Infrastructure.Seeders;

public static class ApplicationIdentitySeeder
{
    public static async Task Run(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    }
}
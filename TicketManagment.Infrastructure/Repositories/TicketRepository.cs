using TicketManagment.Application.Repositories;
using TicketManagment.Domain.Entities;
using TicketManagment.Infrastructure.DbContexts;

namespace TicketManagment.Infrastructure.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

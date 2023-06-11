using TicketManagment.Application.Repositories;
using TicketManagment.Domain.Entities;
using TicketManagment.Infrastructure.DbContexts;

namespace TicketManagment.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

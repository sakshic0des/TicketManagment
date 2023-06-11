using TicketManagment.Application.Repositories;
using TicketManagment.Domain.Entities;
using TicketManagment.Infrastructure.DbContexts;

namespace TicketManagment.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

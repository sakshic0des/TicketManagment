using AutoMapper;
namespace TicketManagment.Application.Services.EmployeeService
{
    public class TicketService : BaseService, ITicketService
    {
        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
         
        

    }
}

using TicketManagment.Domain.ViewModels;

namespace TicketManagment.Application.Services.Ticket
{
    public interface ITicketService
    {
        Task<PaginationResultVm<List<TicketListDto>>> GetTicketListAsAJson(TicketPaginationModel model);
         Task<List<DepartmentLookup>> RetrieveDepartments();
        Task<List<EmployeeLookup>> RetrieveEmployessByDepartmentId(int departmentId);
        Task<bool> AddNewTicket(CreateTicketVM model);
    }
}

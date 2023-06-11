using TicketManagment.Application.Repositories;

namespace TicketManagment.Application;

public interface IUnitOfWork
{
    // Repository Interfaces Will Be Added Here
   public IDepartmentRepository DepartmentRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public ITicketRepository TicketRepository { get; }
    Task<int> CompleteAsync();
}
using TicketManagment.Application;
using TicketManagment.Application.Repositories;
using TicketManagment.Infrastructure.DbContexts;
using TicketManagment.Infrastructure.Repositories;

namespace TicketManagment.Infrastructure;

/// <inheritdoc />
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        DepartmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_context)).Value;
        EmployeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context)).Value;
        TicketRepository = new Lazy<ITicketRepository>(() => new TicketRepository(_context)).Value;
    }
    public IDepartmentRepository DepartmentRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public ITicketRepository TicketRepository { get; }
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}
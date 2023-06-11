using Microsoft.EntityFrameworkCore;
using TicketManagment.Domain.Entities;

namespace TicketManagment.Infrastructure.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ticket> Tickets { get; set; } = null!;
    public virtual DbSet<Department> Departments { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Ticket>(entity =>
        {
            entity.Property(e => e.ID);

            entity.Property(e => e.RequestedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Description);
            entity.Property(e => e.DepartmentId);
        });

        builder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.ID);
            entity.Property(e => e.EmployeeName);

            entity.HasOne(d => d.Department)
               .WithMany(p => p.Employees)
               .HasForeignKey(d => d.DepartmentId)
               .HasConstraintName("FK_Employee_Department");
        });

        builder.Entity<Department>(entity =>
        {
            entity.Property(e => e.ID);
            entity.Property(e => e.DepartmentName);

        });
    }
}
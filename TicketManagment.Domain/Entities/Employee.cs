using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagment.Domain.Entities
{
    [Table("Employee")]
    public class Employee:BaseEntity
    {
        public string EmployeeName { get; set; }

        [Column("DepartmentID")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Employees")]
        public virtual Department? Department { get; set; }
    }
}

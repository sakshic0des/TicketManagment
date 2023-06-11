using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManagment.Domain.Entities
{
    [Table("Ticket")]
    public class Ticket:BaseEntity
    {
        public string ProjectName { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

        public int EmployeeId { get; set; }
        public string Description { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}

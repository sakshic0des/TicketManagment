using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Domain.Entities
{
    [Table("Department")]
    public class Department: BaseEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

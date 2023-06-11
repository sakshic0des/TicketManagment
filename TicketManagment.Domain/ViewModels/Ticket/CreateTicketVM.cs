using System.ComponentModel.DataAnnotations;
using TicketManagment.Domain.Resources;

namespace TicketManagment.Domain.ViewModels
{
    public class CreateTicketVM
    {
        [Required(ErrorMessageResourceName = "ProjectNameIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
        public string ProjectName { get; set; }

        [Required(ErrorMessageResourceName = "DepartmentIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
        public int DepartmentId{ get; set; }

        [Required(ErrorMessageResourceName = "EmployeeIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
        public int EmployeeId { get; set; }

        [Required(ErrorMessageResourceName = "DescriptionIsRequired", ErrorMessageResourceType = typeof(SharedResources))]
        public string Description { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}

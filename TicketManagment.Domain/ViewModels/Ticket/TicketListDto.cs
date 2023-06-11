
namespace TicketManagment.Domain.ViewModels
{
    public class TicketListDto
    {
        public int TicketId { get; set; }
        public string ProjectName { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string RequestedDate { get; set; }

        public TicketListDto(TicketManagment.Domain.Entities.Ticket ticket)
        {
            TicketId = ticket.ID;
            ProjectName = ticket.ProjectName;
            Description = ticket.Description;
            RequestedDate = ticket.RequestedDate.ToString("dd/MM/yyyy hh:mm:ss tt");
            DepartmentName = ticket.Department.DepartmentName;
        }
    }
}

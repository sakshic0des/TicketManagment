using TicketManagment.Domain.Entities;

namespace TicketManagment.Domain.ViewModels
{
    public class TicketListQueryResult
    {
        public Pagination Pagination { get; set; }
        public List<TicketListDto> Tickets { get; set; }

    }
}

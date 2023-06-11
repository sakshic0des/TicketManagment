namespace TicketManagment.Domain.ViewModels
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public string Order { get; set; }
        public string OrderDir { get; set; }
        public int Draw { get; set; }
        public string SearchValue { get; set; }
    }
}

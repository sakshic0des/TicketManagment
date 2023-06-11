namespace TicketManagment.Domain.ViewModels
{
    public class PaginationResultVm<T> where T : class
    {
        public int draw { get; set; }
        public T data { get; set; }
        public int recordsTotal { get; set; }
        public int totalPages { get; set; }
        public int recordsFiltered { get; set; }
    }
}

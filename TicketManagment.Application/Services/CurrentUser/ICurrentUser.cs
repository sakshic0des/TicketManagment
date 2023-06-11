
using TicketManagment.Domain.ViewModels;

namespace TicketManagment.Application
{
    public interface ICurrentUser
    {
        string Name { get; }
        int Language { set; get; }
        void SetLanguage(string language);
        Pagination SetPagination(List<string> Coulmns = null);
    }
}

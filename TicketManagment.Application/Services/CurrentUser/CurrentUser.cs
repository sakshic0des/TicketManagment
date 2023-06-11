using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Globalization;
using System.Net.Http;
using System.Security.Claims;
using TicketManagment.Domain.ViewModels;

namespace TicketManagment.Application
{
    public class CurrentUser : ICurrentUser
    {
        ClaimsPrincipal user;
        HttpRequest httpRequest;
        public CurrentUser(IHttpContextAccessor httpAccessor)
        {
            httpRequest = httpAccessor.HttpContext?.Request;
            user = httpAccessor.HttpContext?.User;
        }

        public CurrentUser(int language)
        {
            this.Language = language;
        }

        public CurrentUser()
        {

        }

        public string Name => user.Claims.FirstOrDefault(obj => obj.Type == "Name")?.Value;
        public string Email => user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;

        public  Pagination SetPagination(List<string> Coulmns = null)
        {
            httpRequest.Form.TryGetValue("start", out StringValues start);

            httpRequest.Form.TryGetValue("search[value]", out StringValues searchValue);
            httpRequest.Form.TryGetValue("draw", out StringValues draw);
            httpRequest.Form.TryGetValue("order[0][column]", out StringValues order);
            httpRequest.Form.TryGetValue("order[0][dir]", out StringValues orderDir);
            Convert.ToInt32(httpRequest.Form.TryGetValue("length", out StringValues pageSize));
            int PageNumber = Convert.ToInt32(start, CultureInfo.CurrentCulture);
            int PageSize = Convert.ToInt32(pageSize, CultureInfo.CurrentCulture);
            int intOrder = Convert.ToInt32(order, CultureInfo.CurrentCulture);
            int Draw = Convert.ToInt32(draw, CultureInfo.CurrentCulture);
            string ColOrder = (Coulmns != null) ? (GetOrderCoulmn(Coulmns, intOrder)) : ("");
            var Pagination = new Pagination() { OrderDir = orderDir, Order = ColOrder, PageNumber = PageNumber, PageSize = PageSize, Draw = Draw,SearchValue= searchValue };
            return Pagination;
        }
        public static string GetOrderCoulmn(List<string> Coulmns, int intOrder)
        {
            string ColOrder = null;
            if (Coulmns != null)
            {
                ColOrder = Coulmns[intOrder];
            }
            return ColOrder;
        }
        public int Language { set; get; }
        public void SetLanguage(string language)
        {
            switch (language)
            {
                case "ar":
                    Language = 1;
                    break;

                default:
                    Language = 2;
                    break;
            }
        }
    }
}

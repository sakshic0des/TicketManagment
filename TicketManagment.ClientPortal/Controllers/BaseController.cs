using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace TicketManagment.ClientPortal.Controllers
{
    public class BaseController : Controller
    {
        protected  List<SelectListItem> GetCultures()
        {
            var defaultCultures = new List<CultureInfo>()
            {
                new CultureInfo("fr-FR"),
                new CultureInfo("en-US"),
            };

            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cultureItems = cinfo.Where(x => defaultCultures.Contains(x))
                .Select(c => new SelectListItem { Value = c.Name, Text = c.DisplayName })
                .ToList();
            return cultureItems;
        }
    }
}

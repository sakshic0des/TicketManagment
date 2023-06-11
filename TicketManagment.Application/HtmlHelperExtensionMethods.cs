using Microsoft.AspNetCore.Mvc.Rendering;
using TicketManagment.Domain.Resources;

namespace TicketManagment.Application
{
    public static class HtmlHelperExtensionMethods
    {
        public static string Translate(this IHtmlHelper helper, string key)
        {
            string result= new System.Resources.ResourceManager(typeof(SharedResources)).GetString(key.ToString());
            return result;
        }
    }
}

using Azure.Core;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using TicketManagment.Application.Services.Ticket;

namespace TicketManagment.ClientPortal.Controllers
{
    public class TicketController : BaseController
    {
        public ITicketService _ticketService { get; set; }
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public IActionResult Index()
        {
            var cultureItems = GetCultures();
            ViewData["Cultures"] = cultureItems;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetAllTicketsAsJson(TicketPaginationModel model)
        {
            try
            {
                if (model.pagination == null)
                {
                     model = new TicketPaginationModel();
                     var data = await _ticketService.GetTicketListAsAJson(model);
                    return Json(data);
                }
                return Json(new { succeded = "error", hasError = true, data = "" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> RetrieveDepartments()
        {
            var result = await _ticketService.RetrieveDepartments();
            if (result != null)
                return Json(new { succeded = "succeded", hasError = false, data = result });
            return Json(new { succeded = "error", hasError = true, data = "" });
        }

        [HttpPost]
        public async Task<ActionResult> RetrieveEmployessByDepartmentId(int departmentId)
        {
            var result = await _ticketService.RetrieveEmployessByDepartmentId(departmentId);
            if (result != null)
                return Json(new { succeded = "succeded", hasError = false, data = result });
            return Json(new { succeded = "error", hasError = true, data = "" });
        }

        public async Task<ActionResult> CreateTicket(CreateTicketVM model)
        {
            var result = await _ticketService.AddNewTicket(model);
            if (result)
                return Json(new { succeded = "succeded", hasError = false, data = result });
            return Json(new { succeded = "error", hasError = true, data = "" });
        }
        [HttpPost]
        public async Task<ActionResult> PartialTicketList()
        {
            return PartialView("_TicketList", null);
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using TicketManagment.Domain;

namespace TicketManagment.Application
{
    public class RequestValidator
    {
        private readonly RequestDelegate _next;

        public RequestValidator(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Because OPTIONS Come Without Token. 
            if (context.Request.Method != "OPTIONS")
            {
                ICurrentUser currentUser = context.RequestServices.GetService(typeof(ICurrentUser)) as ICurrentUser;

                context.Request.Headers.TryGetValue("culture", out StringValues langVal);

                if (!string.IsNullOrEmpty(langVal))
                {
                    var CurrentLanguage = langVal.ToString();
                    currentUser.SetLanguage(CurrentLanguage);
                }
            }
            await _next(context);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Helpers
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute(bool Administrator, bool Uposlenik, bool Korisnik) : base(typeof(RestoranAuthorization))
        {
            Arguments = new object[] { Administrator, Uposlenik, Korisnik };
        }
    }
    public class RestoranAuthorization : IAsyncActionFilter
    {
        private readonly bool Administrator;
        private readonly bool Uposlenik;
        private readonly bool Korisnik;

        public RestoranAuthorization(bool Administrator, bool Uposlenik, bool Korisnik)
        {
            this.Administrator = Administrator;
            this.Uposlenik = Uposlenik;
            this.Korisnik = Korisnik;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var jwt = context.HttpContext.GetJwt();

            if (string.IsNullOrEmpty(jwt))
            {
                if (context.Controller is Controller controller)
                {
                    controller.TempData["error_message"] = "Niste se prijavili";
                }
                context.Result = new RedirectToActionResult("Index", "Prijava", new { @area = "" });
                return;
            }

            var token = JwtParser.Parse(jwt);
            var role = token.Claims.First(claim => claim.Type == "role").Value;

            if(role == "Administrator" && Administrator)
            {
                await next();
                return;
            }

            if (role == "Uposlenik" && Uposlenik)
            {
                await next();
                return;
            }

            if (role == "Korisnik" && Korisnik)
            {
                await next();
                return;
            }
        }
    }
}

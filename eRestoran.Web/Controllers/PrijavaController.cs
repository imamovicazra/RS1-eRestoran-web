using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Controllers
{
    public class PrijavaController : Controller
    {
        private readonly IAuthApi _authApi;
        private readonly KorpaHelper _korpaHelper;
        public PrijavaController(IAuthApi authApi,KorpaHelper korpaHelper)
        {
            _authApi = authApi;
            _korpaHelper = korpaHelper;
        }
        public IActionResult Index(LoginRequest model)
        {
            return View(model);
        }

        public async Task<IActionResult> Prijava(LoginRequest model)
        {
            var response = await _authApi.LoginAsync(model);
            if(response.StatusCode == HttpStatusCode.OK)
            {
               
                HttpContext.SetJwt(response.Content.Token);

                var jwt = response.Content.Token;
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);

                var role = token.Claims.First(claim => claim.Type == "role").Value;

                switch (role)
                {
                    case "Administrator":
                        return Redirect("/Administrator/Home/Index");
                    case "Uposlenik":
                        return Redirect("/Uposlenik/Home/Index");
                    case "Korisnik":
                        return Redirect("/Korisnik/Home/Index");
                    default:
                        return Redirect("/Home/Index");
                }
            }
            else
            {
                TempData["error_message"] = ErrorParser.Parse(response.Error.Content);

                return View(nameof(Index), model);
            }
        }

        public async Task<IActionResult> OdjavaAsync()
        {
            HttpContext.DeleteJwt();
            await _korpaHelper.IzbrisiStavkeAsync();
            return Redirect(nameof(Index));
        }
    }
}

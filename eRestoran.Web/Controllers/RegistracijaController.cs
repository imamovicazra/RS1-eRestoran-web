using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Controllers
{
    public class RegistracijaController : Controller
    {
        private readonly IAuthApi _authApi;

        public RegistracijaController(IAuthApi authApi)
        {
            _authApi = authApi;
        }

        public IActionResult Index()
        {
            return View(new RegisterRequest());
        }

        public async Task<IActionResult> Registracija(RegisterRequest model)
        {
            var response = await _authApi.RegisterAsync(model);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Redirect("/Prijava");
            }
            else
            {
                TempData["error_message"] = ErrorParser.Parse(response.Error.Content);
                return View(nameof(Index), model);
            }

        }
    }
}

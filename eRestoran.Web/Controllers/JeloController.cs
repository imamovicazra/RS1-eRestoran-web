using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class JeloController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        public JeloController(IRestoranApi restoranApi)
        {
            _restoranApi = restoranApi;
        }
        
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Prikaz(string category, int page=1, string search=null)
        {
            var filter = new JeloSearchRequest()
            {
                Kategorija = category, 
                Naziv=search
            };

            var paginationQuery = new PaginationQuery(page, 9);
            var x =await _restoranApi.GetJeloAsync(filter, paginationQuery);
            JeloPrikazVM model = new JeloPrikazVM
            {
                Content = x.Content,
                TrenutnaKategorija = string.IsNullOrEmpty(category) ? "Sva jela" : category,
                Search=search,
                kateg=category

            };
            return View(model);
        }
    }
}

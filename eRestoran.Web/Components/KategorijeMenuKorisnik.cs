using eRestoran.Contracts.Responses;
using eRestoran.Sdk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Components
{
    public class KategorijeMenuKorisnik:ViewComponent
    {
        private readonly IRestoranApi _restoranApi;
        public KategorijeMenuKorisnik(IRestoranApi restoranApi)
        {
            _restoranApi = restoranApi;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _restoranApi.GetKategorijaAsync();
            List<KategorijaResponse> kategorije = response.Content.Data.ToList();

            return View(kategorije);
        }
    }
}

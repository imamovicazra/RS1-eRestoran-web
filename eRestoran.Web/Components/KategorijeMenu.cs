using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using eRestoran.Sdk;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Komponente
{
    public class KategorijeMenu:ViewComponent
    {
        private readonly IRestoranApi _restoranApi;
        public KategorijeMenu(IRestoranApi restoranApi)
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

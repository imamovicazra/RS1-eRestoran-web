using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using eRestoran.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Helpers
{
    public class KorpaHelper : IKorpaHelper
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;
        public string ID { get; set; }
        public List<KorpaStavkaResponse> stavke { get; set; }
        public KorpaHelper(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public static KorpaHelper GetKorpa(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = service.GetService<IRestoranApi>();
            var map = service.GetService<IMapper>();
            string korpaID = session.GetString("KorpaID") ?? Guid.NewGuid().ToString();
            session.SetString("KorpaID", korpaID);
            return new KorpaHelper(context,map) { ID = korpaID };
        }
        public async Task DodajUKorpuAsync(Jelo jelo, int kolicina)
        {
            var x = await _restoranApi.GetKorpaStavkaAsync();
            //var s = x.Content.Data.SingleOrDefault(
            //    s => s.JeloID == jelo.ID && s.KorpaID == ID);
            var stavka = x.Content.Data
                .SingleOrDefault(s => s.JeloID == jelo.ID && s.KorpaID == ID);
            if (stavka == null)
            {

                KorpaStavkaUpsertRequest upsert = new KorpaStavkaUpsertRequest
                {
                    JeloID = jelo.ID,
                    Kolicina = 1,
                    KorpaID = ID
                };
                await _restoranApi.CreateKorpaStavkaAsync(upsert);
            }
            else
            {
                stavka.Kolicina++;
                KorpaStavkaUpsertRequest upsert = new KorpaStavkaUpsertRequest
                {
                    JeloID = jelo.ID,
                    Kolicina = stavka.Kolicina,
                    KorpaID = ID
                };

                await _restoranApi.UpdateKorpaStavkaAsync(stavka.ID,upsert);
            }
        }



        public async Task<int> UkloniIzKorpeAsync(Jelo jelo)
        {
            var x = await _restoranApi.GetKorpaStavkaAsync();
            var stavka = x.Content.Data.SingleOrDefault(
                s => s.JeloID == jelo.ID && s.KorpaID == ID);
            //KorpaStavka stavka = _mapper.Map<KorpaStavka>(s);
            var kolicina = 0;
            if (stavka != null)
            {
                if (stavka.Kolicina > 1)
                {
                    stavka.Kolicina--;
                    kolicina = stavka.Kolicina;
                    KorpaStavkaUpsertRequest upsert = new KorpaStavkaUpsertRequest
                    {
                        JeloID = jelo.ID,
                        Kolicina = stavka.Kolicina,
                        KorpaID = ID
                    };

                    await _restoranApi.UpdateKorpaStavkaAsync(stavka.ID, upsert);

                }
                else
                {
                    await _restoranApi.DeleteKorpaStavkaAsync(stavka.ID);
                }
            }
            return kolicina;
        }
        public async Task<List<KorpaStavkaResponse>> GetStavkeAsync()
        {
            var x = await _restoranApi.GetKorpaStavkaAsync();
            var stavke = x.Content.Data.Where(x => x.KorpaID == ID).ToList();
            
            return stavke;
        }
        public async Task IzbrisiStavkeAsync()
        {
            await _restoranApi.OcistiKorpu(ID);
        }
        public async Task<double> UkupnoAsync()
        {
            var x = await _restoranApi.GetKorpaStavkaAsync();
            var total = x.Content.Data.Where(k=>k.KorpaID== ID)
                .Select(c => c.Jelo.Cijena * c.Kolicina).Sum();
            return total;

        }
    }
}

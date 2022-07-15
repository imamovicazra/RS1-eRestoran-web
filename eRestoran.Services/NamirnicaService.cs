using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;
using System.Linq;

namespace eRestoran.Services
{
    public class NamirnicaService :
        CrudService<NamirnicaResponse, NamirnicaSearchRequest, Namirnica, NamirnicaUpsertRequest, NamirnicaUpsertRequest>
    {
        public NamirnicaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Namirnica> ApplyFilter(IQueryable<Namirnica> query, NamirnicaSearchRequest search)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Naziv))
                {
                    query = query.Where(i => i.Naziv.ToLower().Contains(search.Naziv.ToLower()));
                }
            }

            return query;
        }
    }
}

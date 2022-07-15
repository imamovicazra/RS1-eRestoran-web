using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;
using System.Linq;

namespace eRestoran.Services
{
    public class GradService : CrudService<GradResponse, GradSearchRequest, Grad, GradUpsertRequest, GradUpsertRequest>
    {
        public GradService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Grad> ApplyFilter(IQueryable<Grad> query, GradSearchRequest search)
        {
            if (search != null)
            {
                if(!string.IsNullOrEmpty(search.Naziv))
                {
                    query = query.Where(i => i.Naziv.StartsWith(search.Naziv));
                }

                if (search.PostanskiBroj != 0)
                {
                    query = query.Where(i => i.PostanskiBroj == search.PostanskiBroj);
                }
            }

            return query;
        }
    }
}

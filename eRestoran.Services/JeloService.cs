using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public class JeloService : 
        CrudService<JeloResponse, JeloSearchRequest, Jelo, JeloUpsertRequest, JeloUpsertRequest>,
        IJeloService
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public JeloService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async override Task<PagedResponse<JeloResponse>> Get(JeloSearchRequest search, PaginationQuery pagination)
        {
            var query = _context.Set<Jelo>()
                .Include(i => i.Kategorija)
                .AsNoTracking()
                .AsQueryable();

            query = ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.OrderBy(s=>s.Naziv).ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<JeloResponse>>(list), search, pagination);
            return pagedResponse;
        }

        public async Task<bool> Like(int JeloID, int KorisnikID)
        {
            var entity = new Like
            {
                JeloID = JeloID,
                KorisnikID = KorisnikID,
                Datum = DateTime.Now
            };

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Dislike(int JeloID, int KorisnikID)
        {
            var entity = await _context.Likes.FindAsync(KorisnikID, JeloID);          
            if(entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        protected override IQueryable<Jelo> ApplyFilter(IQueryable<Jelo> query, JeloSearchRequest search)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Naziv))
                {
                    query = query.Where(i => i.Naziv.ToLower().Contains(search.Naziv.ToLower()));
                }

                if (!string.IsNullOrEmpty(search.Kategorija))
                {
                    query = query.Where(i => i.Kategorija.Naziv.ToLower().Equals(search.Kategorija.ToLower()));
                }
            }

            return query;
        }
    }
}

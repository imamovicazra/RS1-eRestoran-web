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
    public class RezervacijaService : BaseService<RezervacijaResponse, object, Rezervacija>, IRezervacijaService
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public RezervacijaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Set<Rezervacija>().FindAsync(id);

            try
            {
                _context.Set<Rezervacija>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override async Task<PagedResponse<RezervacijaResponse>> Get(object search, PaginationQuery pagination)
        {
            var query = _context.Rezervacije
                .Include(i => i.Korisnik)
                .Include(i => i.Uposlenik)
                .Where(i => i.DatumVrijemeRezervacije >= DateTime.Now)
                .AsNoTracking()
                .AsQueryable();

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<RezervacijaResponse>>(list), search, pagination);
            return pagedResponse;
        }

        public async Task<RezervacijaResponse> Insert(int korisnikID, RezervacijaInsertRequest request)
        {
            var entity = _mapper.Map<Rezervacija>(request);
            entity.KorisnikID = korisnikID;

            _context.Rezervacije.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<RezervacijaResponse>(entity);
        }

        public async Task<RezervacijaResponse> Update(int id, int korisnikID)
        {
            var entity = await _context.Rezervacije.FindAsync(id);
            _context.Rezervacije.Attach(entity);
            _context.Rezervacije.Update(entity);

            entity.UposlenikID = korisnikID;
            entity.DatumVrijemeEvidencije = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<RezervacijaResponse>(entity);
        }
    }
}

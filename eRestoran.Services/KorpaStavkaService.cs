using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public class KorpaStavkaService : CrudService<KorpaStavkaResponse, KorpaStavkaSearchRequest, KorpaStavka, KorpaStavkaUpsertRequest, KorpaStavkaUpsertRequest>, IKorpaStavkaService
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public KorpaStavkaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async override Task<PagedResponse<KorpaStavkaResponse>> Get(KorpaStavkaSearchRequest search, PaginationQuery pagination)
        {
            var query = _context.Set<KorpaStavka>()
                .Include(j=>j.Jelo)
                .ThenInclude(j => j.Kategorija)
                .AsNoTracking()
                .AsQueryable();

            query = ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<KorpaStavkaResponse>>(list), search, pagination);
            return pagedResponse;
        }

        public async Task<bool> OcistiKorpu(string KorpaID)
        {
            var stavke = _context.KorpaStavke.Where(korpa => korpa.KorpaID == KorpaID);
            if (stavke != null)
            {
                _context.KorpaStavke.RemoveRange(stavke);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}

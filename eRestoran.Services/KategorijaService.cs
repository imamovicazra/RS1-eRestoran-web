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
    public class KategorijaService : CrudService<KategorijaResponse, KategorijaSearchRequest, Kategorija, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public KategorijaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async override Task<PagedResponse<KategorijaResponse>> Get(KategorijaSearchRequest search, PaginationQuery pagination)
        {
            var query = _context.Set<Kategorija>()
                .AsNoTracking()
                .AsQueryable();

            ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<KategorijaResponse>>(list), search, pagination);
            return pagedResponse;
        }

       
    }
}

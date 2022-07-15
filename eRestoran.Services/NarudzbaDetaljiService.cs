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
    public class NarudzbaDetaljiService :
          CrudService<NarudzbaDetaljiResponse, NarudzbaDetaljiSearchRequest, NarudzbaDetalji, NarudzbaDetaljiUpsertRequest, NarudzbaDetaljiUpsertRequest>
      {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        public NarudzbaDetaljiService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async override Task<PagedResponse<NarudzbaDetaljiResponse>> Get(NarudzbaDetaljiSearchRequest search, PaginationQuery pagination)
        {
            var query = _context.Set<NarudzbaDetalji>()
                .Include(j => j.Jelo)
                .Include(n=>n.NarudzbaID)
                .AsNoTracking()
                .AsQueryable();

            query = ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<NarudzbaDetaljiResponse>>(list), search, pagination);
            return pagedResponse;
        }    

      
    }
}

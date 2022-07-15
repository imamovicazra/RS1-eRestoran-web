using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IBaseService<TModel, TSearch> where TDatabase : class
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;

        public BaseService(eRestoranContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public virtual async Task<PagedResponse<TModel>> Get(TSearch search, PaginationQuery pagination)
        {
            var query = _context.Set<TDatabase>()
                .AsNoTracking()
                .AsQueryable();

            query = ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<TModel>>(list), search, pagination);
            return pagedResponse;
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await _context.Set<TDatabase>().FindAsync(id);
            return _mapper.Map<TModel>(entity);
        }

        protected async Task<PagedResponse<TModel>> GetPagedResponse(List<TModel> list, TSearch search, PaginationQuery pagination)
        {
            var query = _context.Set<TDatabase>()
                .AsNoTracking()
                .AsQueryable();

            query = ApplyFilter(query, search);

            int count = await query.CountAsync();
            
            return PaginationHelper.CreatePaginatedResponse(pagination, list, count);
        }

        protected virtual IQueryable<TDatabase> ApplyFilter(IQueryable<TDatabase> query, TSearch search)
        {
            return query;
        }
    }
}

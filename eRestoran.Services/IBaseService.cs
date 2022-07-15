using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IBaseService<T, TSearch>
    {
        Task<PagedResponse<T>> Get(TSearch search, PaginationQuery pagination);
        Task<T> GetById(int id);
    }
}

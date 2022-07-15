using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface ICrudService<T, TSearch, TInsert, TUpdate> : IBaseService<T, TSearch>
    {
        Task<T> Insert(TInsert request);
        Task<T> Update(int id, TUpdate request);
        Task<bool> Delete(int id);
    }
}

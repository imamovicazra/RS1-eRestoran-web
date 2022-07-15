using eRestoran.Contracts.Responses;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IAnalyticsService
    {
        Task<OrdersByMonthResponse> GetOrdersByMonth(int? year);
    }
}

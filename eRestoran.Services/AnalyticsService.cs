using eRestoran.Contracts.Responses;
using eRestoran.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly eRestoranContext _context;

        public AnalyticsService(eRestoranContext context)
        {
            _context = context;
        }

        public async Task<OrdersByMonthResponse> GetOrdersByMonth(int? year)
        {
            var narudzbe = await _context.NarudzbaDetalji
                .Include(i => i.Narudzba)
                .AsNoTracking()
                .ToListAsync();

            if(year != null)
            {
                narudzbe = narudzbe
                    .Where(i => Convert.ToDateTime(i.Narudzba.DatumNarudzbe).Year == year)
                    .ToList();
            }

            var data = narudzbe
                .GroupBy(i => Convert.ToDateTime(i.Narudzba.DatumNarudzbe).Month)
                .Select(i => new OrdersByMonthResponse.Cell()
                {
                    Month = i.Key,
                    NumberOfOrders = i.Count(),
                    TotalSum = i.Sum(j => j.Cijena)
                })
                .ToList();
                
            var response = new OrdersByMonthResponse
            {
               Data = data
            };
            return response;
        }
    }
}

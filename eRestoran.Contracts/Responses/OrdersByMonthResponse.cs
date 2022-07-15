using System.Collections.Generic;

namespace eRestoran.Contracts.Responses
{
    public class OrdersByMonthResponse
    {
        public List<Cell> Data { get; set; }
        public class Cell
        {
            public int Month { get; set; }
            public int NumberOfOrders { get; set; }
            public double TotalSum { get; set; }
        }
    }
}

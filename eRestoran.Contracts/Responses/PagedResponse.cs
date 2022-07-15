using System.Collections.Generic;

namespace eRestoran.Contracts.Responses
{
    public class PagedResponse<T>
    {
        public PagedResponse() { }
        public PagedResponse(IEnumerable<T> response)
        {
            Data = response;
        }
        
        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int FirstPage { get; set; }
        public int? LastPage { get; set; }
    }
}

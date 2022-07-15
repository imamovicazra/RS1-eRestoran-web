using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eRestoran.Shared.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(PaginationQuery pagination, List<T> response, int count)
        {
            int LastPageNumber = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(count) / pagination.PageSize));

            var nextPage = pagination.PageNumber >= 1 && pagination.PageNumber < LastPageNumber
                ? pagination.PageNumber + 1
                : (int?)null;

            var previousPage = pagination.PageNumber - 1 >= 1
                ? pagination.PageNumber - 1
                : (int?)null;

            var firstPage = 1;

            var lastPage = LastPageNumber;

            return new PagedResponse<T>
            {
                Data = response,
                PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
                PageSize = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null,
                NextPage = response.Any() ? nextPage : null,
                PreviousPage = previousPage,
                FirstPage = firstPage,
                LastPage = lastPage
            };
        }
    }
}

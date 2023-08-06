using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.SuperMarket.Utilities
{
    public static class PaginationHelper
    {
        public static PaginationResult<T> PaginateData<T>(IEnumerable<T> items, int page, int pageSize)
        {
            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var paginatedItems = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var response = new PaginationResult<T>
            {
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize,
                Items = paginatedItems
            };

            return response;
        }
    }
}
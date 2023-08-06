using System.Collections.Generic;

namespace BackEnd.SuperMarket.Utilities
{
    public class PaginationParameters
    {
        public int PageNumber {get; set;} =1;
        public int PageSize {get; set;} = 10;
        public string? SearchTerm {get; set;}
    }

    public class PaginationResult<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }
    }

}
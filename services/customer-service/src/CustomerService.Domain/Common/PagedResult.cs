using System.Collections.Generic;
using System; // Added

namespace GymFlow.CustomerService.Domain.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PaginationMetadata Pagination { get; set; }

        public PagedResult() { }

        public PagedResult(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            Data = data;
            Pagination = new PaginationMetadata
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };
        }
    }

    public class PaginationMetadata
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}

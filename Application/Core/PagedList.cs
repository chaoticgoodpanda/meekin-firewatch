using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Core
{
    // inherits everything in the List class and then extends the List class to give it some pagination properties
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int count) : base(collection)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        
        // IQueryable because receive list of items before cast to list in DB
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            // get count of items before pagination has taken place so we know total number of items in list
            var count = await source.CountAsync();

            // retrieve the items
            // in order to get first 10 records, get page # - 1 (0) multiplied by pageSize (e.g. 10) = 0
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            // return paginated list of results, count, pageSize, pageNumber
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
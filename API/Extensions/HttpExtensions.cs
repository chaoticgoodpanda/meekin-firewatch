using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    // static class because it's an extension method (used elsewhere)
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage,
            int totalItems, int totalPages)
        {
            var paginationHeader = new
            {
                currentPage,
                itemsPerPage,
                totalItems,
                totalPages
            };
            // add these parameters to our response
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader));
            
            // need to expose special "Pagination" header so our browser can read it
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using projectMVC.UnitOfWork;

namespace projectMVC.Models
{
    public class PaginationList<T> : List<T>
    {
         
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

		public PaginationList( List<T> items , int count , int pageIndex,int pageSize )
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count/ (double)pageSize ); //total of all pages
            this.AddRange(items);
        }

        public bool HasPrevPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginationList<T>> CreateAsync( IQueryable<T> source , int pageIndex,int pageSize )
        {
            var count = await source.CountAsync(); //number of all products
            var items = await source.Skip( (pageIndex-1) * pageSize ).Take(pageSize).ToListAsync();
            return new PaginationList<T>(items,count,pageIndex,pageSize);
        }
    }
}

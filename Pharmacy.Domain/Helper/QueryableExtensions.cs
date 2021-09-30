using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Pharmacy.Domain.Helper
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> SortSource<T>(this IQueryable<T> source, string sortExpression)
        {
            if (sortExpression == null)
            {
                return source;
            }

            source = source.OrderBy(sortExpression);
            return source;
        }

        public static IQueryable<T> FilterSource<T>(this IQueryable<T> source, string filterExpression)
        {
            if (filterExpression == null)
            {
                return source;
            }

            source = source.Where(filterExpression);
            return source;
        }
    }
}

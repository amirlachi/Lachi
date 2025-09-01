using Azure.Core;

using Lachi.Models.Common;

using System.Linq.Expressions;
using System.Reflection;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lachi.Utilities
{
    public static class ActionRequest
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, BaseRequest request)
        {
            // ---- Filters ----
            if (request.Filters != null)
            {
                foreach (var filter in request.Filters)
                {
                    var parameter = Expression.Parameter(typeof(T), "x");
                    Expression property = parameter;

                    foreach (var member in filter.FieldName.Split('.'))
                        property = Expression.PropertyOrField(property, member);

                    var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                    Expression? comparison = filter.OperatorType switch
                    {
                        FilterRequestOperatorType.Equals => Expression.Equal(property, constant),
                        FilterRequestOperatorType.NotEquals => Expression.NotEqual(property, constant),
                        FilterRequestOperatorType.GreaterThan => Expression.GreaterThan(property, constant),
                        FilterRequestOperatorType.GreaterOrEqualThan => Expression.GreaterThanOrEqual(property, constant),
                        FilterRequestOperatorType.LessThan => Expression.LessThan(property, constant),
                        FilterRequestOperatorType.LessOrEqualThan => Expression.LessThanOrEqual(property, constant),
                        FilterRequestOperatorType.Contains => Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant),
                        _ => throw new InvalidOperationException("فیلتر انتخابی معتبر نمی باشد!")
                    };

                    if (comparison != null)
                    {
                        var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);
                        query = query.Where(lambda);
                    }
                }
            }

            // ---- Sorting ----
            if (request.Sorts != null && request.Sorts.Any())
            {
                IOrderedQueryable<T>? orderedQuery = null;

                foreach (var sort in request.Sorts)
                {
                    var parameter = Expression.Parameter(typeof(T), "x");
                    Expression property = parameter;

                    foreach (var member in sort.Field.Split('.'))
                        property = Expression.PropertyOrField(property, member);

                    var lambda = Expression.Lambda(property, parameter);

                    string methodName = orderedQuery == null
                        ? (sort.IsASC ? "OrderBy" : "OrderByDescending")
                        : (sort.IsASC ? "ThenBy" : "ThenByDescending");

                    var result = typeof(Queryable).GetMethods()
                        .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T), property.Type)
                        .Invoke(null, new object[] { orderedQuery ?? query, lambda }) as IOrderedQueryable<T>;

                    orderedQuery = result;
                }

                if (orderedQuery != null)
                    query = orderedQuery;
            }

            //int skip = (request.Page - 1) * request.PageSize;
            //query = query.Skip(skip).Take(request.PageSize);

            return query;
        }
    }
}

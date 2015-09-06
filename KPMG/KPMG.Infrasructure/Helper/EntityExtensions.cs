using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using KPMG.Infrasructure.Adapter.Mapping;
using KPMG.Infrasructure.Data.Infrasructure;
using KPMG.Infrasructure.Data.Pagination;
using KPMG.Infrasructure.Engine;

namespace KPMG.Infrasructure.Helper
{
    public static class EntityExtensions
    {

        #region Model mapping

        public static TTarget MapTo<TTarget>(this Entity item) where TTarget : class, new()
        {
            var adapter = EngineContext.Instance.DiContainer.GetInstance<IMapperAdapterFactory>().Create();
            return adapter.Adapt<TTarget>(item);
        }

        public static List<TTarget> MapTo<TTarget>(this IEnumerable<Entity> items)
            where TTarget : class, new()
        {
            var adapter = EngineContext.Instance.DiContainer.GetInstance<IMapperAdapterFactory>().Create();
            return adapter.Adapt<List<TTarget>>(items);
        }

        public static IMappingExpression<TSource, TTarget> IgnoreAllMissingInTarget<TSource, TTarget>(this IMappingExpression<TSource, TTarget> expression)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            foreach (var prop in Mapper.GetAllTypeMaps().First(m => m.SourceType == sourceType && m.DestinationType == targetType).GetUnmappedPropertyNames())
            {
                expression.ForMember(prop, opt => opt.Ignore());
            }
            return expression;
        }

        #endregion

        #region SortOrder by string

        private static IOrderedQueryable<TSource> OrderingHelper<TSource>(IQueryable<TSource> source, string propertyName, SortDirection sortDirection, bool isSubLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(TSource), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, propertyName);
            LambdaExpression sort = Expression.Lambda(property, param);

            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!isSubLevel ? "OrderBy" : "ThenBy") + (sortDirection == SortDirection.Desc ? "Descending" : string.Empty),
                new[] { typeof(TSource), property.Type },
                source.Expression,
                Expression.Quote(sort));

            return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(call);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName, SortDirection sortDirection = SortDirection.Asc)
        {
            return OrderingHelper(source, propertyName, sortDirection, false);
        }

        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> source, string propertyName)
        {
            return OrderBy(source, propertyName, SortDirection.Desc);
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource>(this IOrderedQueryable<TSource> source, string propertyName, SortDirection sortDirection = SortDirection.Asc)
        {
            return OrderingHelper(source, propertyName, sortDirection, true);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return ThenBy(source, propertyName, SortDirection.Desc);
        }

        #endregion

    }
}

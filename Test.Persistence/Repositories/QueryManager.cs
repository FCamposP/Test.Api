using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts;

namespace Test.Persistence.Repositories
{
    /// <summary>
    /// clase generica con funciones de lectura de base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    public sealed class QueryManager<T>(IApplicationDbContext context) : IQueryManager<T>, IDisposable where T : class
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        /// <summary>
        /// Implementacion de consulta de datos, considerando funciones como where, orderby, includes y AsNoTracking
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>>? where = null,
                                            Func<IQueryable<T>,
                                            IOrderedQueryable<T>>? orderBy = null,
                                            List<Expression<Func<T, object>>>? includes = null,
                                            bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet.TagWith(_dbSet.GetType().GenericTypeArguments[0].FullName!);

            if (disableTracking) query = query.AsNoTracking();
            if (includes != null)
            {
                query = query.AsSplitQuery();
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            };
            if (where != null) query = query.Where(where);
            if (orderBy != null) return orderBy(query);

            return query;
        }

        public IApplicationDbContext GetDbContext()=>_context;
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contracts
{
    public interface IQueryManager<T> where T : class
    {
        IQueryable<T> Query(Expression<Func<T, bool>>? where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            List<Expression<Func<T, object>>>? includes = null,
            bool disableTracking = true);
        IApplicationDbContext GetDbContext();
    }
}

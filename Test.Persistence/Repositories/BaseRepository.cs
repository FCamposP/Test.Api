using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts;

namespace Test.Persistence.Repositories
{
    /// <summary>
    /// Clase generica con funciones para crear y actualizar registros en base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="iQuerable"></param>
    public sealed class BaseRepository<T>(IQueryManager<T> iQuerable) : IBaseRepository<T>, IDisposable where T : class
    {
        private readonly IQueryManager<T> _iQuerable = iQuerable;
        private readonly DbSet<T> _dbSet;
        private readonly IApplicationDbContext _applicationDbContext=iQuerable.GetDbContext();

        public IQueryable<T> Query(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
                => _iQuerable.Query(where, orderBy, includes, disableTracking);

        /// <summary>
        /// Metodo para implementacion de creacion de registros de cualqueir tipo de entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> CreateEntity(T entity)
        {
            var entityResp = await _dbSet.AddAsync(entity);
            await SaveChanges();

            return entityResp.Entity;
        }

        private async Task<bool> SaveChanges()
        {
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public IApplicationDbContext GetDbContext() => _applicationDbContext;


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            GC.Collect();
            GC.SuppressFinalize(this);
        }

      }
}

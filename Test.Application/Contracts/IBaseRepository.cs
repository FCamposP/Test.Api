using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contracts
{
    public interface IBaseRepository<T> : IQueryManager<T> where T : class
    {
        //funciones para creación y actualizacion
        Task<T> CreateEntity(T entity);

    }
}

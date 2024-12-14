using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts;

namespace Test.Domain
{
    public class Help
    {
        /// <summary>
        /// Facilita la implementacion de SoftDelete con el campo IsActive
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static LambdaExpression? GenerateQueryFilterLambda(Type type)
        {
            var parameter = Expression.Parameter(type, "w");
            var falseConstantValue = Expression.Constant(true);
            var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsActive));
            var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
            var lambda = Expression.Lambda(equalExpression, parameter);

            return lambda;
        }
    }
}

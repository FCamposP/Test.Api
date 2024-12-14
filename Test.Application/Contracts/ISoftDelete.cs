using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Contracts
{
    /// <summary>
    /// Implementacion de SoftDelete, el sistema solo mostrará registros activos a nivel de base de datos (registros con el campo IsActive=true)
    /// </summary>
    public interface ISoftDelete
    {
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public static class AssemblyReference
    {
        /// <summary>
        /// Facilita la obtencion de las entidades en configuracion de ApplicationDbContext
        /// </summary>
        public static Assembly Assembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }
    }
}

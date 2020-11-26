using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CantidadInexistenteException:Exception
    {
        public CantidadInexistenteException(string msj)
            : base(msj)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacimientoInvalidoException:Exception
    {
        public NacimientoInvalidoException(string msj)
           : base(msj)
        {

        }
    }
}

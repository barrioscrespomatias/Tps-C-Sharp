using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ColonoRepetidoException:Exception
    {
        public ColonoRepetidoException(string msj)
            :base(msj)
        {

        }
    }
}

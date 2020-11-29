using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class GrupoRepetidoException:Exception
    {
        public GrupoRepetidoException(string msj)
            : base(msj)
        {

        }
    }
}

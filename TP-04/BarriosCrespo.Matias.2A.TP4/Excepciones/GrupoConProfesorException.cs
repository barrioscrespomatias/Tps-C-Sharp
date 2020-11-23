using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class GrupoConProfesorException:Exception
    {
        public GrupoConProfesorException(string msj)
            :base(msj)
        {

        }
    }
}

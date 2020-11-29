using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValidacionIncorrectaException : Exception
    {
        public ValidacionIncorrectaException(string msj)
           : base(msj)
        {
        }
    }
}

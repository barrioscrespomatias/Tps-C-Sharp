using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// Llama al constructor por defecto pasándole un string con el error.
        /// </summary>
        public DniInvalidoException()
            : this("Excepcion: el DNI es inválido.")
        {

        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            : this(new DniInvalidoException().Message, e)
        {

        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        /// <summary>
        /// Construcor por defecto
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor que llama al constructor por defecto.
        /// </summary>
        public NacionalidadInvalidaException() : this("La nacionalidad no se condice con el número de DNI")
        {
        }
        
    }
}

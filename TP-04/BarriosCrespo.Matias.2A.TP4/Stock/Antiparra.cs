using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stock
{

    public class Antiparra : Producto
    {
        private EMarca marca;
        private ConsoleColor color;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Antiparra()
        {

        }
        /// <summary>
        /// Constructor 3 parámetros.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        /// <param name="precio"></param>
        public Antiparra(EMarca marca, ConsoleColor color, double precio)
        {
            this.marca = marca;
            this.color = color;
            this.precio = precio;
            this.cantidad = 1;

            this.codigo = 002;
        }

        public EMarca Marca
        {
            get { return this.marca; }
        }

        /// <summary>
        /// Sobrecarga == entre dos antiparras.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Antiparra a, Antiparra b)
        {
            bool retorno = false;
            if (a.marca == b.marca)
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga != entre dos antiparras.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Antiparra a, Antiparra b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Hace públicos los datos de la clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("Marca {0} - Precio: {1}\n", this.marca, this.precio);
            return sb.ToString();
        }
    }
}

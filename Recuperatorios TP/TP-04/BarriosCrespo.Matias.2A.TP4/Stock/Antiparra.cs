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
        public Antiparra(EMarca marca, EColores color, double precio, int cantidad)
        {
            this.marca = marca;
            this.color = color;
            this.precio = precio;
            this.cantidad = cantidad;

            this.codigo = 002;
        }

        public EMarca Marca
        {
            get { return this.marca; }
        }

        #region Sobercargas      

        /// <summary>
        /// Sobrecarga == entre dos antiparras.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Antiparra a, Antiparra b)
        {
            bool retorno = false;
            if (a.marca == b.marca && a.precio == b.precio && a.color == b.color)
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
        /// Sobrecarga Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Antiparra)
                retorno = this == (Antiparra)obj;

            return retorno;

        }

        #endregion

        /// <summary>
        /// Hace públicos los datos de la clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("{0} - ${1:N2} - {2} - Cantidad: {3}\n", this.marca, this.precio, this.color, this.cantidad);
            return sb.ToString();
        }

      

    }
}

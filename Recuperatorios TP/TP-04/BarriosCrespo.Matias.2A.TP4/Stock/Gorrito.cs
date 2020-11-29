using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Stock
{

    public class Gorrito : Producto
    {

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Gorrito()
        {

        }
        /// <summary>
        /// Constructor 2 parámetros.. Hardcodea cantidad y codigo.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="precio"></param>
        public Gorrito(EColores color, double precio, int cantidad)
        {
            this.color = color;
            this.precio = precio;
            this.cantidad = cantidad;
            this.codigo = 001;
        }

        #region Sobrecargas  


        /// <summary>
        /// Sobrecarga == entre dos gorritos. Si son del mismo color son iguales.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Gorrito a, Gorrito b)
        {
            bool retorno = false;
            if (a.color == b.color && a.precio == b.precio && a.color == b.color)
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga != entre dos gorritos.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Gorrito a, Gorrito b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Sobrecarga Equals Gorrito
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Gorrito)
                retorno = this == (Gorrito)obj;

            return retorno;

        }
        #endregion

        /// <summary>
        /// Sobrecarga ToString. Expone los datos de la clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("{0} - ${1:N2} - Cantidad: {2}\n", this.color, this.precio, this.cantidad);
            return sb.ToString();
        }




    }
}

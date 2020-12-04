using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Stock
{
    [XmlInclude(typeof(Gorrito))]
    [XmlInclude(typeof(Antiparra))]
    public class Producto
    {
        public double precio;
        protected int codigo;
        protected int cantidad;
        protected EColores color;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Producto()
        {

        }


        #region Propiedades        
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public EColores Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        #endregion

        #region Sobrecargas        
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Producto)
                retorno = this == (Producto)obj;

            return retorno;

        }
        /// <summary>
        /// Sobrecarga == entre dos productos. Son iguales si tiene el mismo precio y mismo código.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            bool retorno = false;
            if (p1.precio == p2.precio && p1.codigo == p2.codigo && p1.color == p2.color)
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga != entre dos productos.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Sobrecarga + entre un producto y una cantidad. No lo usé.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static Producto operator +(Producto p1, int cantidad)
        {
            p1.cantidad += cantidad;
            return p1;
        }
        /// <summary>
        /// Sobrecarga implicit retorna la cantidad de un producto. No lo usé.
        /// </summary>
        /// <param name="g1"></param>
        public static implicit operator int(Producto g1)
        {
            return g1.cantidad;
        }

        #endregion

        /// <summary>
        /// Expone los atributos de clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} ", this.GetType().Name);
            return sb.ToString();
        }


    }
}

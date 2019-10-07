using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// Clase abstracta Producto.
    /// </summary>
    public abstract class Producto
    {       
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #region enumerados
        /// <summary>
        /// Enumerado de Marcas de productos.
        /// </summary>
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }
        #endregion
        #region constructores
        /// <summary>
        /// Constructo por defecto de Productos. Inicializa todos sus atributos.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion
        #region propiedades
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected virtual short CantidadCalorias { get; }
        #endregion
        #region metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Retorna string</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion
        #region sobrecargas
        /// <summary>
        /// Sobrecarga explicita de "string". Mostrará los datos del producto. 
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendFormat("---------------------\n");
            return sb.ToString();
        }
        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>True en caso de que sean iguales, caso contrario false.</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;
           // if (!Object.Equals(v1, null) && Object.Equals(v2, null))
            {
                if (v1.codigoDeBarras == v2.codigoDeBarras)
                    retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorna true en caso de que sean distintos. Caso contrario false</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion

    }
}

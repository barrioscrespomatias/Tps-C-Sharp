using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        //Tipo por defecto "Entera".
        ETipo tipo = ETipo.Entera;

        /// <summary>
        /// Enumerado de tipos de Leches.
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }
        #region constructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this(marca, codigo, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Construtor de Leche. Inicializa los atritubos menos el tipo, que por defecto es "Entera". Llama a base.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color):base(codigo,marca,color)
        {
            
        }
        #endregion
        #region propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion
        #region sobrecarga metodos
        /// <summary>
        /// Sobreescritura del metodo mostrar (Producto).
        /// </summary>
        /// <returns>Retorna string con la informacion</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("LECHE\n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : " + this.tipo);
            sb.AppendFormat(" \n");
            sb.AppendFormat("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}

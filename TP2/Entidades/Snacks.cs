using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region "constructores"
        /// <summary>
        /// Constructor por defecto de Snacks. Llama al construcotr base y le pasa los atributos.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }
        #endregion
        #region propiedades
        /// <summary>
        /// Propiedad de solo lectura "Cantidad de calorias".
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion
        #region sobrecarga metodos
        /// <summary>
        /// Sobreescritra del metodo Mostrar (Producto). Mostrará solo los snacks. 
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("SNACKS\n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendFormat("");
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}

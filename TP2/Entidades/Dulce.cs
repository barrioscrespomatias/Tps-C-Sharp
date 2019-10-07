using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor por defecto de Dulces. Llama a base para inicializar sus atributos.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }
        #region propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion
        #region sobrecarga metodos
        /// <summary>
        /// Sobrecarga de Mostrar (Producto). Metodo sellado.
        /// </summary>
        /// <returns>Retorna cadena con la informacion.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DULCE\n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendFormat("");
            sb.AppendFormat("---------------------");
            return sb.ToString();
        }
        #endregion

    }
}

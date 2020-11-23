using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// El mismo realiza una extensión de la Clase Colono. Ha sido implementado para abonar la cuota 
    /// (y elementos que compre el colono) bajando su deudo a cero y aumentando el saldo de la colonia.
    /// </summary>
    public static class ExtensionColonoPagaCuota
    {
        public static double PagarCuota(this Colono c1, Colono colono, Colonia colonia)
        {
            double retorno = 0;

            if (colono.Deuda > 0)
            {
                colonia.SaldoActual += colono.Deuda;
                retorno = colono.Deuda;
                colono.Deuda = 0;
            }

            return retorno;
        }

    }
}

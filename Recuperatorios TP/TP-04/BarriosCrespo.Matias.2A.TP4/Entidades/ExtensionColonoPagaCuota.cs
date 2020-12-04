using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Extension de la clase Colono. Ha sido implementado para abonar la cuota 
    /// (y elementos que compre el colono) bajando su deudo a cero y aumentando el saldo de la colonia.
    /// Implementa la escritura en 2 archivos de texto en done se guardan los pagos con la descripcion y el
    /// importe.
    /// </summary>
    public static class ExtensionColonoPagaCuota
    {
        public static void PagarDeudas(this Colono claseColono, Colono colono, Colonia catalinas)
        {
            if (colono.SaldoCuota+colono.SaldoProductos > 0)
            {
                catalinas.SaldoActual += colono.SaldoProductos+colono.SaldoCuota;
                Colonia.GuardarPagos(colono);
                Colonia.GuardarImporte(catalinas);
                colono.SaldoProductos = 0;
                colono.SaldoCuota = 0;
                Console.WriteLine("Se han saldado las deudas de "+colono.Apellido+" "+colono.Nombre);

            }
        }
    }
}

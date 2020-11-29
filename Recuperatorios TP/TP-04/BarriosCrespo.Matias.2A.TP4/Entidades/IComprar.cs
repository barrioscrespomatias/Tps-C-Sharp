using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock;

namespace Entidades
{
    /// <summary>
    /// Es la
    //encargada de desarrollar las ventas de los productos que la colonia tiene en stock.
    //Mediante el método implementado, se elimina el producto de la lista de posibles ventas y se carga el
    //importe del producto a las deudas del colono.Mediante un botón “Comprar” del
    //frmMostrarColonos, se conseguirá realizar lo anteriormente mencionado.
    /// </summary>
    public interface IComprar
    {
        void RealizaVenta(Colonia colonia, Producto producto, Colono colono, int cantidad);
    }
}

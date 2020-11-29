using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Stock;
using Excepciones;
using BaseDatos;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Colonia catalinas = new Colonia("Catalinas");
            Colono colonoUno = new Colono("Rene", "Perez", new DateTime(2008, 10, 06), 1111, EPeriodoInscripcion.Mes);
            Colono colonoDos = new Colono("Juan", "Carlos", new DateTime(2007, 5, 09), 2222, EPeriodoInscripcion.Quincena);
            Colono colonoRepetido = new Colono("Mateo", "Uribe", new DateTime(2013, 8, 22), 2222, EPeriodoInscripcion.Semana);
            

            //Productos

            Gorrito g1 = new Gorrito(EColores.Amarillo, 200f, 10);
            Antiparra a1 = new Antiparra(EMarca.Pirulito, EColores.Rojo, 500f, 10);

            catalinas.ProductosEnVenta += g1;
            catalinas.ProductosEnVenta += a1;
            try
            {
                catalinas += colonoUno;
                catalinas += colonoDos;
                catalinas += colonoRepetido;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Elimina colonoDos.
            catalinas -= colonoDos;

            
            //Agrega al colonoRepetido
            //Irá a un grupo distinto ya que sus rangos etarios no coinciden.
            catalinas += colonoRepetido;


            //Colono numero1 compra producto.
            //La venta achica el stock y suma deuda al saldo del colono.
            catalinas.RealizaVenta(catalinas, g1, colonoUno, 1);

            //ColonoDos Compra 5 uniades del g1 pero NO paga sus deudas-
            catalinas.RealizaVenta(catalinas, g1, colonoRepetido, 5);

            //Colono que compró paga sus deudas: Cuota+Gorrito de $200. = total $3700.-            
            colonoUno.PagarDeudas(colonoUno, catalinas);
       
            
            Console.WriteLine(colonoUno.ToString()+"***************************");
            Console.WriteLine(colonoRepetido.ToString() + "***************************");


            Console.WriteLine("Productos en venta\n\n"+catalinas.ProductosEnVenta);
            Console.WriteLine(catalinas.ToString());

            Console.ReadKey();
        }
    }
}

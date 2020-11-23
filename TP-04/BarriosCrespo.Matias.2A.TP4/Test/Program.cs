using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Stock;
using Excepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Colonia catalinas = new Colonia("Catalinas");

            //Colonos

            Colono c1 = new Colono("Rene", "Perez", new DateTime(2008, 10, 06), 1111, EPeriodoInscripcion.Mes);

            Colono c2 = new Colono("Juan", "Carlos", new DateTime(2016, 5, 09), 2222, EPeriodoInscripcion.Quincena);


            Colono c3 = new Colono("Mateo", "Uribe", new DateTime(2013, 8, 22), 3333, EPeriodoInscripcion.Semana);

            Colono c4 = new Colono("Nicolas", "Avellaneda", new DateTime(2007, 10, 06), 4444, EPeriodoInscripcion.Mes);
            Colono c5 = new Colono("Puente", "Pueyrredon", new DateTime(2010, 5, 09), 5555, EPeriodoInscripcion.Quincena);
            Colono c6 = new Colono("Aristóbulo", "Del Valle", new DateTime(2017, 8, 22), 6666, EPeriodoInscripcion.Semana);

            Colono c7 = new Colono("Roque", "Saenz Peña", new DateTime(2000, 10, 06), 7777, EPeriodoInscripcion.Mes);
            Colono c8 = new Colono("Manuel", "Belgrano", new DateTime(1990, 5, 09), 8888, EPeriodoInscripcion.Quincena);
            Colono c9 = new Colono("Don José", "De San Martin", new DateTime(2020, 8, 09), 9999, EPeriodoInscripcion.Semana);

            //Profesores

            Profesor p1 = new Profesor("Lautaro", "Martinez", new DateTime(1985, 1, 15), 3333, 25000f);
            Profesor p2 = new Profesor("Mike", "Amigorena", new DateTime(1991, 11, 17), 4444, 25000f);
            Profesor p3 = new Profesor("Toni", "Kroos", new DateTime(1998, 7, 29), 5555, 25000f);


            //Productos

            Gorrito g1 = new Gorrito(ConsoleColor.Yellow, 1);
            Gorrito g2 = new Gorrito(ConsoleColor.Green, 1);
            Gorrito g3 = new Gorrito(ConsoleColor.Red, 1);

            Antiparra a1 = new Antiparra(EMarca.Pirulito, ConsoleColor.Red, 500f);
            Antiparra a2 = new Antiparra(EMarca.Adidas, ConsoleColor.Green, 100f);
            Antiparra a3 = new Antiparra(EMarca.Speedo, ConsoleColor.Yellow, 150);


            //Agregar productos a la lista genérica
            catalinas.ProductosEnVenta += g1;
            catalinas.ProductosEnVenta += g2;
            catalinas.ProductosEnVenta += g3;

            try
            {
                catalinas.ProductosEnVenta += a1;
            }
            catch (StockMaximoException exe)
            {
                Console.WriteLine(exe.Message);
            }

            //Carga de colonos

            try
            {
                catalinas += c1;
                catalinas += c2;
                //catalinas -= c1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                catalinas += c4;
                catalinas += c5;
                catalinas += c6;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                catalinas += c7;
                catalinas += c8;
                //catalinas -= c9;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                catalinas += p1;
                catalinas += p2;
                catalinas += p3;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(catalinas.ProductosEnVenta);
            Console.WriteLine(catalinas.ToString());


            //Serializacion
            catalinas.SerializacionXml();     

           



            Console.ReadKey();
        }
    }
}

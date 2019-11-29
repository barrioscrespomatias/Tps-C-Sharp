using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class PaquetesRepetidos
    {
        [TestMethod]
        public void TestMethod1()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Andres Baranda 214", "0000000001");
            Paquete p2 = new Paquete("Republica del Libano 1356", "0000000001");


            try
            {
                c += p1;
                c += p2;

                Assert.Fail("No se pueden agregar dos paquetes con el mismo TRACKING ID");
            }

            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
            


        }
    }
}

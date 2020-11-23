using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace AgregarColono
{
    [TestClass]
    public class TestAgregarColono
    {
        [TestMethod]
        public void TesteoAgregar()
        {
            //Arrange    
            Colonia catalinas = new Colonia("Catalinas");
            Colono a = new Colono("Pedrito", "Alvarado", new DateTime(2011, 11, 02), 2222, EPeriodoInscripcion.Mes);

            //Act
            catalinas += a;

            //Verifica igualdad en algumnos.
            bool retorno = catalinas == a;

            //Assert
            Assert.IsTrue(retorno);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class ListaPaquetesCorreo
    {
        [TestMethod]
        public void TestPaqueteCorreo()
        {
            //Arrange
            Correo aux;
            //Act
            aux = new Correo();
            //Assert
            Assert.AreNotEqual(aux.Paquetes, null);

        }
    }
}

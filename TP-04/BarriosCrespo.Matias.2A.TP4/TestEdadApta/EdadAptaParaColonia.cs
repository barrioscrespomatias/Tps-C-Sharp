using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestEdadApta
{
    [TestClass]
    public class EdadAptaParaColonia
    {
        [TestMethod]
        public void VerificaEdadCorrectaParaInscripcion()
        {
            //Arrange
            Colono laChiqui = new Colono("Mirtha", "Legrand", new DateTime(1927, 02, 23), 7967, EPeriodoInscripcion.Mes);

            //Act
            bool colonoValido = Colono.EsValido(laChiqui);

            //Assert
            Assert.IsFalse(colonoValido);
        }
    }
}

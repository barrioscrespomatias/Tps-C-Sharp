using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Validaciones;
using Entidades;


namespace TestValidaciones
{
    [TestClass]
    public class SoloLetras
    {
        [ExpectedException(typeof(ValidacionIncorrectaException))]
        [TestMethod]
        public void VerificaValidacionLetras()
        {
            //Arrange      
            Colono unColono = new Colono();

            //Act
            unColono.Nombre = Validaciones.Validar.ValidarSoloLetras("Juan 7 Carlos");
            Console.WriteLine(unColono.Nombre);
            
            //Assert
            Assert.IsTrue(unColono.Nombre == null);

        }
    }
}

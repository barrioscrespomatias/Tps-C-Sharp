using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestAlumnoRepetido
{
    [TestClass]
    public class AlumnoRepetido
    {
        [TestMethod]
        public void VerificaAlumnoRepetido()
        {
            //Arrange

            bool alumnosRepetidos = false;
            Colonia catalinas = new Colonia("Catalinas");
            Colono a = new Colono("Juan", "Perez", new DateTime(2015, 11, 05), 1111, EPeriodoInscripcion.Quincena);
            Colono b = new Colono("Pedro", "Rodriguez", new DateTime(2017, 10, 06), 1111, EPeriodoInscripcion.Mes);

            //Act     
            catalinas += a;
            catalinas += b;

            alumnosRepetidos = a == b;

            //Assert
            Assert.IsTrue(alumnosRepetidos);



        }
    }
}

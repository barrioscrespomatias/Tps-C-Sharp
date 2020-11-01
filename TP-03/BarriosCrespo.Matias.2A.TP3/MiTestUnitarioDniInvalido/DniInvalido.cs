using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones;
using EntidadesAbstractas;

namespace MiTestUnitarioDniInvalido
{
    /// <summary>
    /// Testea que el dni del alumno sea correcto. Si es correcto 
    /// se guarda el dni. Sino se guarda 0. Al guardarse cero se
    /// genera una excepcion NacionalidadInvalidaException ya que
    /// un DNI no puede ser menor a 1. 
    /// </summary>
    [TestClass]
    public class NacionalidadInvalidaPorDni
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TesteoErrorDni()
        {
            //Arrange           
            Alumno a = new Alumno(1, "Juan", "Perez", "11222333", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            //Act            
            a.StringToDNI = "1122233A";

            //Assert
            Assert.IsTrue(a.DNI == 0);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using System.Collections.Generic;

namespace MiTestUnitarioInstanciaAtributoColeccion
{
    [TestClass]
    public class InstanciaDeColeccion
    {
        /// <summary>
        /// Verifica que la coleccion List<Alumnos> de la clase
        /// Jornada haya sido instanciada.
        /// </summary>
        [TestMethod]
        public void VerifcaInstanciaDeColeccion()
        {
            //Arrange
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, new Profesor());
            
            //Assert
            Assert.IsNotNull(j.Alumnos);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;


namespace MiTestUnitarioAlumnoRepetido
{
    [TestClass]
    public class AlumnoRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void VerificaExistenciaAlumnosRepetidos()
        {
            //Arrange
            bool alumnosRepetidos;
            Universidad uni = new Universidad();
            Alumno a = new Alumno(1, "Juan", "Perez", "11222333", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno b = new Alumno(1, "Juan", "Perez", "11222333", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            //Act
            uni += a;
            uni += b;
            //Verifica igualdad en algumnos.
            alumnosRepetidos = b == a;

            //Assert
            Assert.IsTrue(alumnosRepetidos);
        }
    }
}

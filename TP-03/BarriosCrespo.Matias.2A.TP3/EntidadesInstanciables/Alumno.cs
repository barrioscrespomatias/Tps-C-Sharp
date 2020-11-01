using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region constructores
        /// <summary>
        /// 
        /// </summary>
        public Alumno() : base()
        {

        }
        /// <summary>
        /// Constructor por defecto 6 parámetros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor 7 parámetros. Llama al constructor por defecto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
        : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region metodos
        /// <summary>
        /// Muestra todos los datos del alumno. Sobreescritura del método virtual
        /// Universitario.MostrarDatos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.Becado:
                    sb.AppendFormat("ESTADO DE CUENTA: {0}\n", "Becado.");
                    break;

                default:
                    sb.AppendFormat("ESTADO DE CUENTA: {0}\n", "Cuota al día.");
                    break;

            }
            sb.AppendFormat(this.ParticiparEnClase());
            return sb.ToString();
        }


        /// <summary>
        /// Retorna una cadena con la informacion de la clase que toma el alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASE DE {0}\n\n", this.claseQueToma);
            return sb.ToString();
        }
        /// <summary>
        /// Hace públicos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region sobrecargas
        /// <summary>
        /// Sobrecarga igualdad entre Alumno y clase.
        /// Un alumno es igual a la clase si su estado de cuenta no es deudor y la 
        /// clase que toma es igual  a la clase pasada por parámetro.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si toma la clase y su estado cuenta NO es deudor. Sino false</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (a.estadoCuenta != EEstadoCuenta.Deudor)
                if (a.claseQueToma == clase)
                    retorno = true;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga distinto entre Alumno y clase. Un alumno es distinto a una clase si la clase
        /// que toma es distinta a la clase pasada por parámetro.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Si es distinto retorna true, sino false.</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma != clase)
                retorno = true;

            return retorno;
        }
        #endregion


    }
}

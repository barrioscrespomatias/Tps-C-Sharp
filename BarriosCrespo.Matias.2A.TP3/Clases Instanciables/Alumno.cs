using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region constructores       
        public Alumno()
        {

        }
        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {

        }

        #endregion

        #region sobrecargas opereadores
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {

        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {

        }


        #endregion

        #region metodos
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            ///AGREGAR EL MOSTRAR DE ESTADO CUENTA Y CLASE QUE TOMA
            sb.AppendFormat(this.ToString());            
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TOMA CLASE DE: {0}", this.claseQueToma);
            return sb.ToString();

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ///RECORRERLO PARA VER LAS CLASES
            sb.AppendFormat("CLASES DEL DIA: {0}",this.claseQueToma);
            sb.AppendFormat("ESTADO DE CUENTA: {0}", this.estadoCuenta);
            return sb.ToString();

        }
        #endregion
    }
}

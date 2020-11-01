using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// 
        /// </summary>
        public Universitario() : base()
        {

        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #region sobrecargas
        /// <summary>
        /// Sobrecarga Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
                retorno = this == (Universitario)obj;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga == Universitario. Serán iguales si son del mismo tipo y su legajo
        /// o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna true si son iguales, sino false.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI))
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga != Universitario.
        /// Son distintos si:
        /// a)Son de distinto tipo.
        /// b)Son del mismo tipo pero son de DNI y Legajo distinto.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna True si son distintos. Sino false.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        #endregion

        #region metodos
        /// <summary>
        /// Retorna una cadena con todos los datos de universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n\n", this.Nacionalidad);
            sb.AppendFormat("LEGAJO NÚMERO: {0}\n", this.legajo);
            return sb.ToString();
        }
        /// <summary>
        /// Método abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


        #endregion

    }
}

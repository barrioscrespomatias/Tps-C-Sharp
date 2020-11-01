using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;


namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        public Profesor() /*: this(0, null, null, null, ENacionalidad.Argentino)*/
        {
            
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        #region metodos
        /// <summary>
        /// Carga las clases aleatoreas que dictará el profesor.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                //Dentro de la cola se carga un dato del enumerado "Eclases" con valores del 0 al 3.
                this.clasesDelDia.Enqueue((EClases)Profesor.random.Next(0, 3));
            }

        }
        /// <summary>
        /// Muestra todos los datos del profesor. Reutiliza Mostra de universitario y 
        /// método abstracto ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            sb.AppendLine("");
            return sb.ToString();
        }
        /// <summary>
        /// Muestra las clases que dicta el profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA: ");
            foreach (EClases aux in this.clasesDelDia)
            {
                sb.AppendFormat(aux.ToString() + "\n");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hace públicos todos los datos del profesor.
        /// </summary>
        /// <returns>Retorna string con todos los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region sobrecargas
        /// <summary>
        /// Igualdad entre profesor y una clase. Es igual si dá esa clase.
        /// </summary>
        /// <returns>Retorna true si el profesor dicta la clase pasada por parámetro
        /// sino, false.</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            foreach (EClases aux in i.clasesDelDia)
            {
                if (clase == aux)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Distinto entre profesor y una clase. Es distinto si el profesor NO dicta la clase.
        /// </summary>
        /// <returns>Si es distinto retorna True, sino false.</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}

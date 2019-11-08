using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region constructores 
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region sobrecargas operadores
        public static bool operator == (Jornada j, Alumno a)
        {
            bool retorno = true;
            foreach(Alumno aux in j.alumnos)
            {
                if(aux == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        #endregion
    }
}

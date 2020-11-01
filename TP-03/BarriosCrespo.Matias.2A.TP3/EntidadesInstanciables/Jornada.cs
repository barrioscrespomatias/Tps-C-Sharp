using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntidadesInstanciables.Universidad;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Constructor por defecto donde se inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor 2 parámetros, llama al constructor por defecto.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #region propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion


        #region sobrecargas
        /// <summary>
        /// Igualdad de alumno con jornada. Sera igual si el alumno participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in j.alumnos)
            {
                if (aux == a)
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
        /// <summary>
        /// Sobrecarga "+". Agrega al alumno a la jornada en caso de que NO
        /// participe en la misma.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Si lo pudo agregar retornada la jornada con el alumno
        /// sino la jornada sin el mismo.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);

            return j;
        }
        /// <summary>
        /// Hace públicos todos los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendFormat("CLASE DE {0} {1}", this.clase, this.instructor.ToString());
            sb.AppendFormat("ALUMNOS: \n");
            foreach (Alumno auxAlumno in this.alumnos)
            {
                if (auxAlumno == this.Clase)
                    sb.AppendFormat(auxAlumno.ToString());
            }
            sb.Append("<------------------------------------------>\n");
            return sb.ToString();
        }

        // METODOS GUARDAR Y LEER
        /// <summary>
        /// Guarda los datos de la jornada dentro de un archivo.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            try
            {
                Texto t = new Texto();
                if (t.Guardar("jornada.txt", jornada.ToString()))
                    retorno = true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message.ToString());
            }


            return retorno;
        }
        /// <summary>
        /// Lee desde un archivo de texto los datos de una jornada. Pasa por parámetro
        /// los datos obtenidos del archivo.
        /// </summary>
        /// <returns>Retorna los datos recuperados desde el archivo de texto.</returns>
        public static string Leer()
        {
            string datos = default;
            try
            {
                Texto t = new Texto();
                t.Leer("jornada.txt", out datos);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return datos;
        }


        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #region propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
     
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion

        #region sobrecargas
        /// <summary>
        /// Sobrecarga  == entre universidad y alumno. Será igual si el alumno está
        /// isncripto en la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true en caso de que el alumno exista en universidad, sino false.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in g.alumnos)
            {
                if (aux == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Sobrecarga != entre alumno y universidad.
        /// Será distinto cuando el alumno no forma parte de la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retornará true en caso de ser distinto, sino false.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Sobrecarga == entre Universidad y profesor. Sera igual si el profesor
        /// dicta clases en dicha universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns>Si es igual retorna true, sino false.</returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            bool retorno = false;
            foreach (Profesor aux in g.profesores)
            {
                if (aux == p)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;

        }
        /// <summary>
        /// Sobrecarga != entre Universidad y profesor. 
        /// Será distinto si el profesor no dicta clases en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns>Si es distinto retorna true, sino false.</returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// Igualdad entre Universidad y Clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Si la clase existe, retorna el profesor que la dicta. Sino, un profesor vacío
        /// y lanza una exception. </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorQueLaDicta = new Profesor();
            bool flag = false;
            for (int i = 0; i < u.jornada.Count; i++)
            {
                if (u.jornada[i].Clase == clase)
                {
                    profesorQueLaDicta = u.jornada[i].Instructor;
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new SinProfesorException();


            return profesorQueLaDicta;
        }

        /// <summary>
        /// Igualdad entre Universidad y clase. Busca al primer profesor que no 
        /// puede dar la clase pasada como parámetro.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna el primer profesor que no puede dar la clase. Sino un profesor vacío.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor queNoDictaClases = new Profesor();
            for (int i = 0; i < u.jornada.Count; i++)
            {
                if (u.jornada[i].Clase != clase)
                {
                    queNoDictaClases = u.jornada[i].Instructor;
                    break;
                }
            }
            return queNoDictaClases;
        }
        /// <summary>
        /// Sobrecarga método "+" entre universidad y clase. Agrega una clase nueva a la universidad
        /// asignandole un profesor y al menos un alumno.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna la universidad.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = new Profesor();
            bool flagProfesor = false;
            bool flagAlumno = false;
            //Recorrer lista de profesores para obtener uno que pueda dictar esa clase.
            foreach (Profesor auxProfesor in g.profesores)
            {
                //Sobrecarga == obtiene un profesor que pueda dictar dicha clase.
                if (auxProfesor == clase)
                {
                    //Asigno en variable "p" el profesor que va a ser titular en la jornada.
                    p = auxProfesor;
                    flagProfesor = true;
                    break;
                }
            }
            //Nueva jornada con profesor y clase.
            Jornada j = new Jornada(clase, p);

            //Recorrer lista de alumnos para obetener los que matcheen entre clase
            // y el atributo claseQueToma de alumno.
            foreach (Alumno auxAlumno in g.alumnos)
            {
                if (auxAlumno == j.Clase)
                {
                    flagAlumno = true;
                    //Agregar al alumno a la jornada.
                    j += auxAlumno;

                }

            }
            //Si fue asignado algun profesor y fue agregado al menos un alumno, agrego la jornada.
            if (flagAlumno && flagProfesor)
                g.jornada.Add(j);
            else
                throw new SinProfesorException();

            return g;

        }
        /// <summary>
        /// Sobrecarga operador + entre Universidad y Alumno. Si el alumno no se encuentra en 
        /// la universidad, lo agrega. Sino lanza excepction AlumnoRepetidoException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Si lo pudo agregar retorna la universidad con el alumno, sino
        /// la universidad sin el alumno.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return u;
        }
        /// <summary>
        /// Sobrecarga operador + entre universidad y profesor. Si el profeosr
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.profesores.Add(i);

            return u;
        }
        #endregion

        #region métodos
        /// <summary>
        /// Muestra la universidad con todos sus datos.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada auxJornada in uni.jornada)
            {
                sb.Append(auxJornada.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga ToString(). Hace pública la informacion de la universidad.
        /// </summary>
        /// <returns>Retorna la toda la informacion de la universdiad.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region miembros implementados de interfaz IArchivo       
        /// <summary>
        /// Guarda los datos de la universidad en un archivo XML.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> x = new Xml<Universidad>();
            if (x.Guardar("universidad.xml", uni))
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// Lee y obtiene los datos de la Universidad desde un archivo XML. 
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> x = new Xml<Universidad>();
            Universidad uni = new Universidad();
            x.Leer("universidad.xml", out uni);
            return uni;
        }
        #endregion   



    }
}

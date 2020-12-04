using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class Grupo
    {
        protected ConsoleColor colorID;
        protected EEdad eDadDelGrupo;
        protected List<Colono> listaDeColonos;
        protected int capacidad;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Grupo()
        {
            this.listaDeColonos = new List<Colono>();
        }

        /// <summary>
        /// Constructor 3 parámetros
        /// </summary>
        /// <param name="capacidad"></param>
        /// <param name="color"></param>
        /// <param name="edadGrupo"></param>
        public Grupo(int capacidad, ConsoleColor color, EEdad edadGrupo) : this()
        {
            this.colorID = color;
            this.capacidad = capacidad;
            this.eDadDelGrupo = edadGrupo;
        }

        #region Propiedades

        public int Capacidad
        {
            get { return this.capacidad; }
        }

        public ConsoleColor ColorId
        {
            get { return this.colorID; }
        }


        public List<Colono> ListadoColonos
        {
            get { return this.listaDeColonos; }
        }


        public EEdad EdadDelGrupo
        {
            get { return this.eDadDelGrupo; }
            set { this.eDadDelGrupo = value; }
        }

        #endregion


        #region sobrecargas de igualdad
        /// <summary>
        /// Sobrecarga == Entre dos grupos.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns>Si tienen el mismo color, retorna true.</returns>
        public static bool operator ==(Grupo g1, Grupo g2)
        {
            bool retorno = false;
            if (g1.colorID == g2.colorID)
                retorno = true;

            return retorno;
        }



        /// <summary>
        /// Sobrecarga != Entre dos grupos.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns>Si tienen el distinto color, retorna true.</returns>
        public static bool operator !=(Grupo g1, Grupo g2)
        {
            return !(g1 == g2);

        }

        /// <summary>
        /// Sobrecarga  == entre el grupo y un colono.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="p1"></param>
        /// <returns>Retorna True si el colono forma parte del grupo.</returns>
        public static bool operator ==(Grupo g1, Colono c1)
        {
            bool retorno = false;
            foreach (Colono aux in g1.listaDeColonos)
            {
                if (aux == c1)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;

        }
        /// <summary>
        /// Sobrecarga  != entre el grupo y un colono.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="p1"></param>
        /// <returns>Retorna True si el colono no forma parte del grupo.</returns>
        public static bool operator !=(Grupo g1, Colono c1)
        {
            return !(g1 == c1);
        }

        #endregion

        #region sobrecargas + / -
        /// <summary>
        /// Agrega los alumnos al grupo. Si el alumno no forma parte del grupo, lo agrega.
        /// Si forma parte no lo agrega.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="c1"></param>
        /// <returns>Si lo agregó retorna la lista con el nuevo colono.</returns>
        public static Grupo operator +(Grupo g1, Colono c1)
        {
            if (g1.listaDeColonos.Count < g1.capacidad)
            {
                if (g1 != c1)
                    g1.listaDeColonos.Add(c1);
                else
                    throw new ColonoRepetidoException("El colono ya se encuentra en el grupo");
            }
            return g1;
        }
        /// <summary>
        /// Sobrecarga  "-" entre Grupo y alumno. Elimina el alumno del grupo
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="c1"></param>
        /// <returns>Si pudo eliminarlo, devuelve el grupo sin el alumno.</returns>
        public static Grupo operator -(Grupo g1, Colono c1)
        {
            if (g1 == c1)
                g1.listaDeColonos.Remove(c1);

            return g1;
        }

        #endregion    


        /// <summary>
        /// Hace públicos los datos del grupo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*************************");
            sb.AppendFormat("Nombre del grupo: {0}\n", this.eDadDelGrupo.ToString());
            //sb.AppendFormat("{0}\n", this.profesorDelGrupo.ToString());
            //sb.AppendFormat("Horario de pileta: {0}\n", this.turnoPileta.ToString());
            sb.AppendFormat("Cantidad de colonos: {0}\n", this.listaDeColonos.Count);
            sb.AppendFormat("Listado de colonos: \n\n");
            foreach (Colono aux in this.listaDeColonos)
            {
                sb.AppendFormat(aux.ToString() + "\n");
            }
            return sb.ToString();

        }
    }
}

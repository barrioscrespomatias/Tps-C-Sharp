using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {

        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            //ESTRUCTURA REPTITIVA
            sb.AppendFormat("{0}\n", clasesDelDia);
            return sb.ToString();

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE: {0} POR NOMBRE COMPLETO {1}\n\n", clasesDelDia, base.MostrarDatos());
            sb.AppendLine("CLASES DEL DIA: \n");
            sb.AppendLine(this.ParticiparEnClase());            
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this.MostrarDatos());
            return sb.ToString();
        }

        private void _randomClases()
        {
            
            int i = 0;
            while(i<2)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(1, 2));
                i++;
            }

        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach(Universidad.EClases aux in i.clasesDelDia)
            {
                if (clase == aux)
                {
                    retorno = true;
                    break;
                }                
            }
            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    sealed class Profesor:Universitario
    {
        private static Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor()
        {
            
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

        private void _randomClases()
        {

        }

    }
}

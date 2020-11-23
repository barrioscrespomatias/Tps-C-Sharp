using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor : Persona
    {
        double salario;

        /// <summary>
        /// Constructor por defecto para serializar
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// Constructor 5 parámetros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        /// <param name="salario"></param>
        public Profesor(string nombre, string apellido, DateTime fechaNacimiento, int dni, double salario)
            : base(nombre, apellido, fechaNacimiento, dni)
        {
            this.salario = salario;

        }

        public double Salario
        {
            get { return this.salario; }            
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}, {1}\n", this.nombre, this.apellido);
            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString());
            sb.AppendFormat("Salario:${0:N2}\n", this.salario);
            return sb.ToString();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        protected int id;
        protected string nombre;
        protected string apellido;
        protected int dni;
        protected DateTime fechaNacimiento;

        //constructor por defecto para serializar
        public Persona()
        {

        }

        /// <summary>
        /// Constructor 4 parámetros.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        public Persona(string nombre, string apellido, DateTime fechaNacimiento, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.dni = dni;
        }

        /// <summary>
        /// Constructor 5 parámetros para TRAER datos de base de datos con ID.
        /// </summary>
        public Persona(string nombre, string apellido, DateTime fechaNacimiento, int dni, int id)
            : this(nombre, apellido, fechaNacimiento, dni)
        {
            this.dni = dni;
        }

        #region Propiedades 

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }
        #endregion

        #region sobrecargas
        /// <summary>
        /// Sobrecarga == entre dos personas. 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Retorna true si tiene el mismo DNI.</returns>
        public static bool operator ==(Persona p1, Persona p2)
        {
            bool retorno = false;

            if (p1.dni == p2.dni)
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// Sobrecarga != entre dos personas.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Retorna true si tienen distinto DNI.</returns>
        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Sobrecarga Equals. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Persona)
                retorno = this == (Persona)obj;
            return retorno;
        }

        #endregion

        #region metodos     

        /// <summary>
        /// Muestra los datos de la persona.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: {1}, {2}\n", this.GetType().Name, this.nombre, this.apellido);
            sb.AppendFormat("DNI: {0}\n", this.dni);
            sb.AppendFormat("Fecha de nacimento: {0}\n", this.fechaNacimiento.ToString("dd/MM/yy"));
            return sb.ToString();
        }

        /// <summary>
        /// Expone los datos de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}

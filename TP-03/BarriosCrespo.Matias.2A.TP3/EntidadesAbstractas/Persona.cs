using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor 3 parámetros.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor 4 parámetros dni int.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        {
        }
        /// <summary>
        /// Constructor 4 parámetros dni string.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.StringToDNI = dni;
            }

            catch (DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region propiedades

        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }


        public int DNI
        {
            get { return this.dni; }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);

            }
        }


        #endregion

        #region metodos
        /// <summary>
        /// Valida que los DNI ingresados sean correctos según Nacionalidad.
        //Argentino entre 1 y 89.999.999 millones
        //Extranjero entre 90.000.000 y 99.999.999 millones.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el DNI correcto. En caso de que no coincida el DNI con la 
        /// nacionalidad lanza excepcion NacionalidadInvalidaException.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            int retorno = default;
            //Para argentinos

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                    retorno = dato;

                else
                    throw new Excepciones.NacionalidadInvalidaException();

            }
            //Para extranjeros
            else if (dato >= 90000000 && dato < 100000000)
                retorno = dato;
            else
                throw new Excepciones.NacionalidadInvalidaException();

            return retorno;
        }

        /// <summary>
        /// Verifica que el dato ingresado sea correcto. Sino lanza excepcion DniInvalidoException.
        /// Si el dato no se puede parsear, lanza excepcion.
        /// Si el dato es mayor o menor del esperado, según la nacionalidad, lanza excepcion NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            int salida = default;
            bool parseo = false;

            try
            {
                parseo = int.TryParse(dato, out salida);
                retorno = this.ValidarDni(nacionalidad, salida);
            }
            catch (DniInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retorno;

        }
        /// <summary>
        /// Recibe como parámetro un dato e intenta parsear cada uno de sus caracteres a entero.
        /// Si lo logra con alguno, devuelve una cadena vacia.         
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            //bool parseaCaracteres = false;
            //int salida = -1;           

            foreach (char c in dato)
            {
                if (!Char.IsLetter(c))
                    return retorno;                    
                //parseaCaracteres = int.TryParse(c.ToString(), out salida);                
                //if (parseaCaracteres)
                //    return retorno;
            }
            //Si valida que el el dato es una cadaena valida, la devuelve.
            return dato;
        }

        #endregion



    }
}

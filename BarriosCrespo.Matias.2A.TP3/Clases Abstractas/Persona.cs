using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region constructores
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionaldiad) : this()
        {

        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, int.Parse(dni), nacionalidad)
        {

        }

        #endregion

        #region propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = value;
            }

        }

        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                try
                {


                    try
                    {       ///FALTA VALIDAR QUE EL VALOR INGRESADO NO SEA UN STRING
                        if (value.ToString().Length < 9)
                        {
                            if (this.Nacionalidad == ENacionalidad.Argentino)
                            {
                                if (this.DNI > 0 && this.DNI < 90000000)
                                {
                                    this.dni = value;
                                }

                            }

                            else
                            {
                                if (this.DNI >= 90000000 && this.DNI < 100000000)
                                {
                                    this.DNI = value;
                                }

                            }
                        }

                    }
                    ///DEBERIA LANZAR NACIONALIDADINVALIDAEXCEPTION
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                ///DEBERIA LANZAR DNIINVALIDOEXCEPTION
                catch (Exception e)
                {

                }

            }

        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }

        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (value is string)
                    this.nombre = value;
            }

        }

        public string StringToDNI
        {
            get
            {
                return this.dni.ToString();
            }

        }




        #endregion

        #region metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.nombre, this.apellido);
            sb.AppendFormat("NACIONALIDAD: {0}\n\n", this.nacionalidad);
            return sb.ToString();
        }
        #endregion

        
    }
}

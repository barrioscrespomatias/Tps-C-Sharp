using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock;
using Excepciones;



namespace Entidades
{
    public class Colono : Persona
    {

        private const int nacimientoLimiteInferior = 2007;
        private const int nacimientoLimiteSuperior = 2017;
        protected bool sinDeudas;
        protected int edad;
        protected EEdad grupo;
        protected DateTime fechaInscripcion;
        protected EPeriodoInscripcion periodo;
        protected EMesIncripcion mes;
        protected double saldoCuota;
        protected double saldoProductos;
        protected List<Producto> productosComprados;


        /// <summary>
        /// Colono por defecto para serializar.
        /// </summary>
        public Colono()
        {
            this.ListaProductosComprados = new List<Producto>();

        }
        /// <summary>
        /// Constructor 5 parámetros sin deuda para crear nuevo  colono desde consola.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        /// <param name="tiempo"></param>       
        public Colono(string nombre, string apellido, DateTime fechaNacimiento, int dni, EPeriodoInscripcion periodo)
           : base(nombre, apellido, fechaNacimiento, dni)
        {
            this.edad = DateTime.Today.Year - this.fechaNacimiento.Year;
            this.grupo = this.AsignarGrupo(edad);
            this.saldoCuota = Colono.CalcularDeuda(this.periodo);
            this.periodo = periodo;
            this.sinDeudas = false;
            this.productosComprados = new List<Producto>();
        }


        /// <summary>
        /// Constructor 6 parámetros con deuda para modificaciones en formulario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        /// <param name="periodo"></param>
        /// <param name="deuda"></param>
        public Colono(string nombre, string apellido, DateTime fechaNacimiento, int dni, EPeriodoInscripcion periodo, double saldoCuota, double saldoProductos)
           : this(nombre, apellido, fechaNacimiento, dni,periodo)
        {
            //this.edad = DateTime.Today.Year - this.fechaNacimiento.Year;
            //this.grupo = this.AsignarGrupo(edad);
            this.saldoCuota = saldoCuota;
            this.saldoProductos = saldoProductos;
            //this.periodo = periodo;
            //this.sinDeudas = false;
            //this.productosComprados = new List<Producto>();
        }
        /// <summary>
        /// Constructor con 7 parámetros para obtener colono desde base de datos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        /// <param name="periodo"></param>
        /// <param name="deuda"></param>
        /// <param name="id"></param>
        public Colono(string nombre, string apellido, DateTime fechaNacimiento, int dni, EPeriodoInscripcion periodo, double saldoCuota, double saldoProductos, int id)
          : this(nombre, apellido, fechaNacimiento, dni, periodo, saldoCuota, saldoProductos)
        {
            this.id = id;
        }

        #region Propiedades
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public List<Producto> ListaProductosComprados
        {
            get { return this.productosComprados; }
            set { this.productosComprados = value; }

        }

        public EPeriodoInscripcion Periodo
        {
            get { return this.periodo; }
            set { this.periodo = value; }
        }

        public EMesIncripcion CargarMes
        {
            get { return this.mes; }
            set { this.mes = value; }
        }
        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        public EEdad EdadGrupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }

        }

        public double SaldoCuota
        {
            get { return this.saldoCuota; }
            set { this.saldoCuota = value; }

        }

        public double SaldoProductos
        {
            get { return this.saldoProductos; }
            set { this.saldoProductos = value; }
        }

        public bool SinDeudas
        {
            get { return this.sinDeudas; }
            set { this.sinDeudas = value; }
        }

        #endregion

        #region Metodos   

        /// <summary>
        /// Calcula la deuda que tiene el colono según el periodo de inscripcion
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns>Retorna double con la deuda</returns>
        public static double CalcularDeuda(EPeriodoInscripcion tiempo)
        {
            double deuda = 0;
            switch (tiempo)
            {
                case EPeriodoInscripcion.Mes:
                    deuda = 10000;
                    break;
                case EPeriodoInscripcion.Quincena:
                    deuda = 6000;
                    break;
                case EPeriodoInscripcion.Semana:
                    deuda = 3500;
                    break;
            }
            return deuda;
        }

        /// <summary>
        /// Asigna el alumno a un grupo específico segun su edad.
        /// </summary>
        /// <param name="edad"></param>
        /// <returns>Retorna el grupo correspondiente.</returns>
        public EEdad AsignarGrupo(int edad)
        {
            EEdad aux = EEdad.EdadIncorrecta;

            if (this.edad > 2 && this.edad < 7)
                aux = EEdad.Peques;
            else if (this.edad > 6 && this.edad < 11)
                aux = EEdad.Medianos;
            else if (this.edad > 10 && this.edad < 14)
                aux = EEdad.Grandes;

            return aux;

        }

        /// <summary>
        /// Verifica que un colono ingresante sea válido para la colonia. Teniendo en cuenta sus atributos.
        /// Verifica además que la edad del colono sea apta, teniendo en cuenta su fecha de nacicimiento.
        /// </summary>
        /// <param name="colono"></param>
        /// <returns></returns>
        public static bool EsValido(Colono colono)
        {
            bool retorno = false;
            if
                (
                    colono.Nombre.Length > 0
                    && colono.Apellido.Length > 0
                    && colono.Dni > 0
                    && colono.fechaNacimiento.Year >= nacimientoLimiteInferior
                    && colono.fechaNacimiento.Year <= nacimientoLimiteSuperior
                )
            {
                retorno = true;
            }
            return retorno;
        }
        #endregion

        /// <summary>
        /// Hace pública la infromacion del colono.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {         
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("Edad: {0}\n", this.edad);           
            sb.AppendFormat("Saldo a pagar por cuota:${0:N2}\n", this.saldoCuota);
            sb.AppendFormat("Saldo a pagar por compras:${0:N2}\n", this.saldoProductos);
            sb.AppendFormat("Lista Productos comprados: \n\n");
            foreach (Producto aux in this.productosComprados)
            {                
                sb.AppendFormat("{0} - ${1}\n", aux.GetType().Name, aux.precio);
            }
            
            return sb.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock;


namespace Entidades
{
    public class Colono : Persona
    {
        

        protected int edad;
        protected EEdad grupo;
        protected DateTime fechaInscripcion;
        protected EPeriodoInscripcion periodo;
        protected EMesIncripcion mes;
        protected double estadoDeuda;
        protected List<Producto> productosComprados;


        public List<Producto> ListaProductosComprados
        {
            get { return this.productosComprados; }
           
        }


        public EPeriodoInscripcion CargarPeriodo
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
        }

        public EEdad EdadGrupo
        {
            get { return this.grupo; }

        }

        public double Deuda
        {
            get { return this.estadoDeuda; }
            set { this.estadoDeuda = value; }

        }


        /// <summary>
        /// Colono por defecto para serializar.
        /// </summary>
        public Colono()
        {

        }


        /// <summary>
        /// Constructor 5 parámtros. Llama a base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        /// <param name="tiempo"></param>
        public Colono(string nombre, string apellido, DateTime fechaNacimiento, int dni, EPeriodoInscripcion tiempo)
            : base(nombre, apellido, fechaNacimiento, dni)
        {
            this.edad = DateTime.Today.Year - this.fechaNacimiento.Year;
            this.grupo = this.AsignarGrupo(edad);
            this.estadoDeuda = this.CalcularDeuda(tiempo);

            //Lista de productos vacia.
            this.productosComprados = new List<Producto>();
        }


        /// <summary>
        /// Con deuda para el formulario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="dni"></param>
        /// <param name="tiempo"></param>
        /// <param name="deuda"></param>
        public Colono(string nombre, string apellido, DateTime fechaNacimiento, int dni, EPeriodoInscripcion tiempo, double deuda)
           : base(nombre, apellido, fechaNacimiento, dni)
        {
            this.edad = DateTime.Today.Year - this.fechaNacimiento.Year;
            this.grupo = this.AsignarGrupo(edad);
            this.estadoDeuda = deuda;


            //Lista de productos vacia.
            this.productosComprados = new List<Producto>();
        }


        /// <summary>
        /// Calcula la deuda que tiene el colono según el periodo de inscripcion
        /// </summary>
        /// <param name="tiempo"></param>
        /// <returns>Retorna double con la deuda</returns>
        private double CalcularDeuda(EPeriodoInscripcion tiempo)
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
        private EEdad AsignarGrupo(int edad)
        {
            EEdad aux = EEdad.DemasiadoGrande;

            if (this.edad > 2 && this.edad < 7)
                aux = EEdad.Peques;
            else if (this.edad > 6 && this.edad < 11)
                aux = EEdad.Medianos;
            else if (this.edad > 10 && this.edad < 14)
                aux = EEdad.Grandes;

            return aux;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("Edad: {0}\n", this.edad);
            sb.AppendFormat("Deuda actual:${0:N2}\n", this.estadoDeuda);
            sb.AppendFormat("Lista de productos comprados: \n\n");
            foreach(Producto aux in this.productosComprados)
            {
                sb.AppendFormat(aux.ToString());
            }
            return sb.ToString();
        }



       
      



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Data.Sql;
using System.Data.SqlClient;
using Stock;
using System.Threading;
using BaseDatos;


namespace Formularios
{
    public partial class frmPrincipal : Form
    {
        
        frmMostrarGrupo mostrarGrupo;
        Thread hiloInicial;

        //atributo principal de la colonia.
        public Colonia catalinas = new Colonia("Catalinas");
        frmBuscarColono buscar;

        public SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionDB);
        public VincularDB nuevoVinculo;



        /// <summary>
        /// Constructor sin parámetros. Inicializa hilo de color del formulario principal
        /// </summary>
        public frmPrincipal()
        {
            InitializeComponent();
            hiloInicial = new Thread(new ThreadStart(this.Comenzando));
            hiloInicial.Start();
        }
        /// <summary>
        /// Carga los grupos en la colonia, inicializa los productos en venta, carga los profesores
        /// y productos hardcodeados. Muestra medante messageBox los docentes actuales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.nuevoVinculo = new VincularDB(this.conexion);
            this.catalinas = this.nuevoVinculo.ObtenerColonos(this.catalinas);
            this.catalinas.ProductosEnVenta = new ControlStock<Producto>();
            this.HardcodeoProductos();
        
           
        }
        /// <summary>
        /// Boton que levanta el formulario frmMostrarColonos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarColono_Click(object sender, EventArgs e)
        {       

            frmBuscarColono buscar = new frmBuscarColono(this.catalinas);
            buscar.Owner = this;
            buscar.StartPosition = FormStartPosition.CenterParent;

            if (buscar.ShowDialog() == DialogResult.OK)
                {
                int dniABuscar = buscar.dni;
                Colono auxiliar = this.catalinas.BuscarColono(this.catalinas, dniABuscar);
                frmDatosPersonales mostrarDatos = new frmDatosPersonales(auxiliar,this.catalinas);
                if (mostrarDatos.ShowDialog() == DialogResult.OK)
                {
                    ///Producto vacío en el que se cargarán los datos del producto seleccionado.
                    Producto p = new Producto();

                    frmVenta nuevaVenta = new frmVenta(auxiliar, this.catalinas);
                    nuevaVenta.StartPosition = FormStartPosition.CenterScreen;
                    if (nuevaVenta.ShowDialog() == DialogResult.OK)
                    {
                        //Selecciona la cantidad del combo.
                        int cantidad = nuevaVenta.frmVentaCantidad;
                        this.catalinas.RealizaVenta(this.catalinas, nuevaVenta.producto, nuevaVenta.colono, cantidad);
                        nuevaVenta.frmComboDeSeleccion.Items.Clear();
                        foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
                        {
                            nuevaVenta.frmComboDeSeleccion.Items.Add(aux);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }

            }


        }
        /// <summary>
        /// Boton que levanta el formulario frmMostrarGrupos (filtrados por edad...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarGrupos_Click(object sender, EventArgs e)
        {

            this.mostrarGrupo = new frmMostrarGrupo(this.catalinas);
            this.mostrarGrupo.Owner = this;
            this.mostrarGrupo.StartPosition = FormStartPosition.CenterParent;
            this.mostrarGrupo.Show();
        }
        /// <summary>
        /// Boton que levanta el formulario del alta del alumno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaAlumno_Click(object sender, EventArgs e)
        {
            
            frmAltaColono altaColono = new frmAltaColono(this.catalinas);
            altaColono.StartPosition = FormStartPosition.CenterScreen;

            if (altaColono.ShowDialog() == DialogResult.OK)
            {
                //Mensaje de todo ok ya lo da el alta.
            }
        }

      
        /// <summary>
        /// Boton que muestra los datos de la colonia. Cantidad de dinero saliente por profesores,
        /// cantidad de dinero entrante por cuotas y venta de productos, cantidad de saldo actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntControlador_Click(object sender, EventArgs e)
        {          
            double saldo = 0;
            saldo = this.catalinas.SaldoActual;                  
            MessageBox.Show("El saldo a favor es: $ " + saldo);
        }      

      

        /// <summary>
        /// Hardocodeo de profesores y productos.
        /// </summary>
        private void HardcodeoProductos()
        {            

            Gorrito g1 = new Gorrito(EColores.Amarillo, 200f);
            Gorrito g2 = new Gorrito(EColores.Amarillo, 200f);

            Antiparra a1 = new Antiparra(EMarca.Adidas, EColores.Negro, 500f);
            Antiparra a2 = new Antiparra(EMarca.Adidas, EColores.Negro, 500f);
            Antiparra a3 = new Antiparra(EMarca.Adidas, EColores.Verde, 500f);

            this.catalinas.ProductosEnVenta += g1;
            this.catalinas.ProductosEnVenta += g2;
            this.catalinas.ProductosEnVenta += a1;
            this.catalinas.ProductosEnVenta += a2;
            this.catalinas.ProductosEnVenta += a3;


        }
        /// <summary>
        /// Metodo manejador del evento de hilos. Lindos los colores (?
        /// </summary>
        private void Comenzando()
        {
            Thread.Sleep(1000);
            this.BackColor = Color.Beige;

            for (int i = 0; i < 2; i++)
            {
                this.btnAltaAlumno.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnAltaAlumno.BackColor = (Color)default;
                Thread.Sleep(100);
                this.btnBuscarColono.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnBuscarColono.BackColor = (Color)default;
                Thread.Sleep(100);

                this.btnMostrarGrupos.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnMostrarGrupos.BackColor = (Color)default;
                Thread.Sleep(100);
               

                this.bntControlador.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.bntControlador.BackColor = (Color)default;
                Thread.Sleep(100);
            }
            this.BackColor = (Color)default;
            hiloInicial.Abort();



        }

        //private void btnListadoDeProductosClick(object sender, EventArgs e)
        //{
            //frmBuscarColono buscar = new frmBuscarColono();
            //buscar.StartPosition = FormStartPosition.CenterScreen;

            //if (buscar.ShowDialog() == DialogResult.OK)
            //{
            //    int dniABuscar = buscar.dni;
            //    Colono auxiliar = this.catalinas.BuscarColono(this.catalinas, dniABuscar);
            //    frmDatosPersonales mostrarDatos = new frmDatosPersonales(auxiliar,this.catalinas);
            //    if (mostrarDatos.ShowDialog() == DialogResult.OK)
            //    {
            //        ///Producto vacío en el que se cargarán los datos del producto seleccionado.
            //        Producto p = new Producto();

            //        frmVenta nuevaVenta = new frmVenta(auxiliar, this.catalinas, p);
            //        nuevaVenta.StartPosition = FormStartPosition.CenterScreen;
            //        if (nuevaVenta.ShowDialog() == DialogResult.OK)
            //        {
            //            //Selecciona la cantidad del combo.
            //            int cantidad = nuevaVenta.frmVentaCantidad;
            //            this.catalinas.RealizaVenta(this.catalinas, nuevaVenta.producto, nuevaVenta.colono, cantidad);
            //            nuevaVenta.frmComboDeSeleccion.Items.Clear();
            //            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            //            {
            //                nuevaVenta.frmComboDeSeleccion.Items.Add(aux);
            //            }
            //            this.DialogResult = DialogResult.OK;
            //        }
            //    }
            //}           

        //}

        private void btnListadoDeProductos_Click(object sender, EventArgs e)
        {
            frmAltaProducto nuevoProducto = new frmAltaProducto(this.catalinas);
            nuevoProducto.StartPosition = FormStartPosition.CenterScreen;

            if(nuevoProducto.ShowDialog() == DialogResult.OK)
            {

            }

        }
    }
}

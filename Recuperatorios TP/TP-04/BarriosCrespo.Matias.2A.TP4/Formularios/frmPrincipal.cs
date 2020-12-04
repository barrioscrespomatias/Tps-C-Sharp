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
using System.IO;
using Excepciones;

namespace Formularios
{
    public partial class frmPrincipal : Form
    {

        public Colonia catalinas = new Colonia("Catalinas");
        Thread hiloInicial;
        public SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionDB);
        public VincularDB nuevoVinculo;
        


        /// <summary>
        /// Constructor sin parámetros. 
        /// </summary>
        public frmPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// Inicializa hilo cambia color del formulario principal
        /// Inicializa un nuevo vínculo con la bae de datos, pasándole como parámetro un SqlConnection
        /// Obtiene los colonos de la base de datos, cargándolos en la colonia de la clase.
        /// Obtiene el saldo actual de la colonia desde un archivo.
        /// Hardcodea una lista de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            hiloInicial = new Thread(new ThreadStart(this.Comenzando));
            hiloInicial.Start();            
            this.ActualizarColonia();
            this.catalinas.SaldoActual = Colonia.ObtenerSaldo();
            this.HardcodeoProductos();
            this.Text = "COLONIA CATALINAS SUR";
        }
        /// <summary>
        /// Inicializa un frmBuscarColono pasándole por parámetro una colonia.
        /// Si el DialogResult del formulario devuelve OK (si existe el colono) obtiene una instancia
        /// de el colono que se buscó y lo muestra mediante el formulario frmDatosPersonales.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarColono_Click(object sender, EventArgs e)
        {
            frmBuscarColono buscar = new frmBuscarColono(this.catalinas);
            //Actualiza la colonia con los últimos valores de la base de datos.
            this.catalinas = this.ActualizarColonia();
            buscar.StartPosition = FormStartPosition.CenterScreen;
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                int dniABuscar = buscar.dni;
                Colono auxiliar = this.catalinas.ObtenerDatos(this.catalinas, dniABuscar);
                frmDatosPersonales mostrarDatos = new frmDatosPersonales(auxiliar, this.catalinas);
                mostrarDatos.StartPosition = FormStartPosition.CenterScreen;
                mostrarDatos.ShowDialog();
            }
        }
        /// <summary>
        /// Inicializa una instancia de frmMostrarGrupo a la que le pasa una colonia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarGrupos_Click(object sender, EventArgs e)
        {
            frmMostrarGrupo mostrarGrupo = new frmMostrarGrupo(this.catalinas);
            mostrarGrupo.StartPosition = FormStartPosition.CenterScreen;
            mostrarGrupo.ShowDialog();
        }
        /// <summary>
        /// Inicializa una nueva instancia de frmAltaColono, pasándole por parámetro una colonia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaAlumno_Click(object sender, EventArgs e)
        {
            frmAltaColono altaColono = new frmAltaColono(this.catalinas);
            altaColono.StartPosition = FormStartPosition.CenterScreen;
            altaColono.ShowDialog();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbmProductos_Click(object sender, EventArgs e)
        {
            if (this.catalinas.ProductosEnVenta.CantidadEnStock < this.catalinas.ProductosEnVenta.Capacidad)
            {
                frmAltaProducto nuevoProducto = new frmAltaProducto(this.catalinas);
                nuevoProducto.StartPosition = FormStartPosition.CenterScreen;
                nuevoProducto.ShowDialog();
            }
            else
                MessageBox.Show("No hay mas espacio para guardar productos!\nVenda algo!!!");

        }


        /// <summary>
        /// Muestra el saldo de la colonia: Ingresos por pago de cuotas y venta de productos.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntControlador_Click(object sender, EventArgs e)
        {

            double saldo;
            string pagos;

            this.catalinas.SaldoActual = Colonia.ObtenerSaldo();
            this.catalinas.Pagos = Colonia.ObtenerPagos();

            pagos = this.catalinas.Pagos;
            saldo = this.catalinas.SaldoActual;
            MessageBox.Show("Ingresos en caja: $ " + saldo);
            MessageBox.Show("Lista de pagos: \n" + pagos + "\n\n---------------------\n Total:$" + saldo);
        }
        /// <summary>
        /// Hardocodeo productos.
        /// </summary>
        private void HardcodeoProductos()
        {
            Gorrito g1 = new Gorrito(EColores.Amarillo, 200f, 1);
            Gorrito g2 = new Gorrito(EColores.Amarillo, 200f, 1);

            Antiparra a1 = new Antiparra(EMarca.Adidas, EColores.Negro, 500f, 1);
            Antiparra a2 = new Antiparra(EMarca.Adidas, EColores.Negro, 500f, 1);
            Antiparra a3 = new Antiparra(EMarca.Adidas, EColores.Verde, 500f, 1);

            this.catalinas.ProductosEnVenta += g1;
            this.catalinas.ProductosEnVenta += g2;
            this.catalinas.ProductosEnVenta += a1;
            this.catalinas.ProductosEnVenta += a2;
            this.catalinas.ProductosEnVenta += a3;
        }
        /// <summary>
        /// Metodo manejador del evento de hilos que cambia los colores del formulario.
        /// </summary>
        private void Comenzando()
        {
            Thread.Sleep(1000);
            this.BackColor = Color.Beige;
            for (int i = 0; i < 2; i++)
            {
                this.btnAltaColono.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnAltaColono.BackColor = (Color)default;
                Thread.Sleep(100);

                this.btnBuscarColono.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnBuscarColono.BackColor = (Color)default;
                Thread.Sleep(100);

                this.btnMostrarGrupos.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnMostrarGrupos.BackColor = (Color)default;
                Thread.Sleep(100);

                this.btnAltaProducto.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnAltaProducto.BackColor = (Color)default;
                Thread.Sleep(100);

                this.bntControlador.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.bntControlador.BackColor = (Color)default;
                Thread.Sleep(100);
            }
            this.BackColor = (Color)default;
            hiloInicial.Abort();

        }
        /// <summary>
        /// Conecta a la base de datos obtiene los valores para agregar en la 
        /// instancia de colonia actual.
        /// </summary>
        /// <returns></returns>
        public Colonia ActualizarColonia()
        {
            this.nuevoVinculo = new VincularDB(this.conexion);
            Colonia auxiliar = new Colonia();

            if (this.nuevoVinculo.ProbarConexion())
            {
                auxiliar = this.nuevoVinculo.ObtenerColonos(this.catalinas);
                //this.catalinas = this.nuevoVinculo.ObtenerColonos(this.catalinas);
            }
            else
                MessageBox.Show("No se ha podido conectar a la base de datos");

            return auxiliar;
        }
    }
}

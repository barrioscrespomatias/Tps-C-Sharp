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
using Stock;
using Excepciones;
using System.Data.SqlClient;
using BaseDatos;

namespace Formularios
{
    public partial class frmVenta : Form
    {
        public Colono colono;
        public Colonia catalinas;
        public Producto producto;
        private SqlConnection conexion;
        private VincularDB nuevaConexion;

        public event DelegadoProductos<Producto> EventoStock;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmVenta()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor con un parámetro que recibe una colonia.
        /// </summary>
        /// <param name="catalinas"></param>
        public frmVenta(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }
        /// <summary>
        /// Constructor con 3 parámetros.
        /// Carga en el comboBox los productos disponibles que tiene la colonia para vender.
        /// </summary>
        /// <param name="colono"></param>
        /// <param name="catalinas"></param>
        /// <param name="producto"></param>
        public frmVenta(Colono colono, Colonia catalinas) : this()
        {
            this.colono = colono;
            this.catalinas = catalinas;
            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            {
                this.cmbBoxSeleccionProducto.Items.Add(aux);
            }
        }
        /// <summary>
        /// Bloquea la entrada de datos a los comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.cmbBoxSeleccionProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCantidadProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            if (this.catalinas.ProductosEnVenta.Listado.Count > 0)
                this.cmbBoxSeleccionProducto.SelectedIndex = 0;
            this.Text = "Ventas";

            this.EventoStock += new DelegadoProductos<Producto>(this.catalinas.AnalizaStock);

            this.cmbCantidadProducto.SelectedIndex = 0;
        }

        /// <summary>
        /// Llama al método realizarVenta que se encarga de manipular el stock, la cantidad de
        /// productos disponibles para vender, modificar los valores del saldo de la colonia y
        /// la deuda del colono.
        /// Al realizar la venta actualiza los posibles productos a vender que se muestran en el comboBox.
        /// Lanza evento que controla el stock.
        /// Establece  el DialogResult en OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionDB);
            this.nuevaConexion = new VincularDB(conexion);

            if (this.catalinas.ProductosEnVenta.Listado.Count > 0)
            {
                if (this.nuevaConexion.ProbarConexion())
                {
                    int cantidad = int.Parse(this.cmbCantidadProducto.SelectedItem.ToString());
                    this.catalinas.RealizaVenta(this.catalinas, this.producto, this.colono, cantidad);

                    //modifica el colono en la base de datos(saldo).
                    this.nuevaConexion.ModificarColono(this.colono);
                    //Actualizar valores
                    this.cmbBoxSeleccionProducto.Items.Clear();
                    foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
                    {
                        this.cmbBoxSeleccionProducto.Items.Add(aux);
                    }
                    MessageBox.Show("Venta realizada con exito!");
                    MessageBox.Show(colono.ToString());

                    //Lanzar el evento que controla el stock.
                    string existencia = this.EventoStock(this.producto);
                    MessageBox.Show(existencia);

                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("No se ha podido conectar a la base de datos");
            }
            else
                MessageBox.Show("No hay productos para vender!");
        }




        /// <summary>
        /// Genera un producto con los datos del combobox.
        /// Actualiza los datos del comboBox que permite seleccionar el producto a vender.
        /// Actualiza los datos del comboBox que permite seleccionar la cantidad disponible del producto
        /// a vender.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCantidadProducto.Items.Clear();
            //Cargo el producto
            this.producto = (Producto)cmbBoxSeleccionProducto.SelectedItem;
            //Carga el combo de seleccion de la cantidad disponible del producto que se ha seleccionado.
            for (int i = 1; i <= producto.Cantidad; i++)
            {
                this.cmbCantidadProducto.Items.Add(i);
            }
            this.cmbCantidadProducto.SelectedIndex = 0;
        }
        /// <summary>
        /// Actualiza los productos disponibles para la venta.
        /// </summary>
        private void ActualizarComboBoxProductosEnVenta()
        {
            this.cmbBoxSeleccionProducto.Items.Clear();
            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            {
                this.cmbBoxSeleccionProducto.Items.Add(aux);
            }
        }

        /// <summary>
        /// Establece en DialogResult en Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

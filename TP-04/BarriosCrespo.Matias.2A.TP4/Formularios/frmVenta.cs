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

namespace Formularios
{
    public partial class frmVenta : Form
    {
        public Colono colono;
        public Colonia catalinas;
        public Producto producto;    

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmVenta()
        {
            InitializeComponent();
        }

        public frmVenta(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }

        /// <summary>
        /// constturctor con 3 parámetros.
        /// </summary>
        /// <param name="colono"></param>
        /// <param name="catalinas"></param>
        /// <param name="producto"></param>
        public frmVenta(Colono colono, Colonia catalinas): this()
        {
            this.colono = colono;
            this.catalinas = catalinas;            

            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            {
                this.cmbBoxSeleccionProducto.Items.Add(aux);
            }

        }



        public int frmVentaCantidad
        {
            get { return int.Parse(this.cmbCantidadProducto.Text); }
        }

        public ComboBox frmComboDeSeleccion
        {
            get { return this.cmbBoxSeleccionProducto; }
        }






        /// <summary>
        /// Acepta el formulario y realiza una venta. Elimina los datos del combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            int cantidad = int.Parse(this.cmbCantidadProducto.SelectedItem.ToString());
            this.catalinas.RealizaVenta(this.catalinas, this.producto, this.colono, cantidad);
            
            //Actualizar valores
            this.cmbBoxSeleccionProducto.Items.Clear();            
            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            {
                this.cmbBoxSeleccionProducto.Items.Add(aux);
            }

            ///DEBERIA ACTUALIZAR LOS VALORES DE LA COLONIA           
            MessageBox.Show("Venta realizada con exito!");
            MessageBox.Show(colono.ToString());
            this.DialogResult = DialogResult.OK;


            ////Selecciona la cantidad del combo.
            //int cantidad = int.Parse(this.cmbCantidadProducto.SelectedItem.ToString());
            //this.catalinas.RealizaVenta(this.catalinas, producto, colono, cantidad);
            //this.cmbBoxSeleccionProducto.Items.Clear();
            //foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            //{
            //    this.cmbBoxSeleccionProducto.Items.Add(aux);
            //}

            /////DEBERIA ACTUALIZAR LOS VALORES DE LA COLONIA
            //mostrarColonos = new frmMostrarColonos(this.catalinas);
            //MessageBox.Show("Venta realizada con exito!");
            //MessageBox.Show(colono.ToString());

            //this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Genera un producto con los datos del combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCantidadProducto.Items.Clear();
            //Cargo el producto
            this.producto = (Producto)cmbBoxSeleccionProducto.SelectedItem;

            for (int i = 1; i <= producto.Cantidad; i++)
            {
                this.cmbCantidadProducto.Items.Add(i);
            }


        }
        /// <summary>
        /// Genera un alta de una nueva antiparra. muestra su formulario y captura los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaAntiparra_Click(object sender, EventArgs e)
        {
            frmAltaAntiparra nuevaAntiparra = new frmAltaAntiparra(this.catalinas);
            nuevaAntiparra.StartPosition = FormStartPosition.CenterScreen;
            if (nuevaAntiparra.ShowDialog() == DialogResult.OK)
            {
                //Agregar el producto al stockDeProductos de la colonia

                ///Recorrer y cargar stockDeProductos de la colonia
                this.ActualizarComboBoxProductosEnVenta();



                //this.comboBox1.Items.Add(nuevaAntiparra.ingresante);
                MessageBox.Show("Alta exitosa");
            }
        }
        /// Genera un alta de una nuevo gorrito. muestra su formulario y captura los datos.
        private void btnAltaGorrito_Click(object sender, EventArgs e)
        {
            frmAltaGorrito nuevoGorrito = new frmAltaGorrito(this.catalinas);
            nuevoGorrito.StartPosition = FormStartPosition.CenterScreen;
            if (nuevoGorrito.ShowDialog() == DialogResult.OK)
            {
                this.cmbBoxSeleccionProducto.Items.Add(nuevoGorrito.ingresante);
                MessageBox.Show("Alta exitosa");
            }

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.cmbBoxSeleccionProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCantidadProducto.DropDownStyle = ComboBoxStyle.DropDownList;

        }


        private void ActualizarComboBoxProductosEnVenta()
        {
            this.cmbBoxSeleccionProducto.Items.Clear();
            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            {
                this.cmbBoxSeleccionProducto.Items.Add(aux);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

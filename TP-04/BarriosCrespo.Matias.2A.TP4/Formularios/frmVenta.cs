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
        /// <summary>
        /// constturctor con 3 parámetros.
        /// </summary>
        /// <param name="colono"></param>
        /// <param name="catalinas"></param>
        /// <param name="producto"></param>
        public frmVenta(Colono colono, Colonia catalinas, Producto producto) : this()
        {
            this.colono = colono;
            this.catalinas = catalinas;
            this.producto = producto;

            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (Producto aux in catalinas.ProductosEnVenta.Listado)
            {
                this.comboBox1.Items.Add(aux);
            }
        }
        /// <summary>
        /// Acepta el formulario y realiza una venta. Elimina los datos del combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.catalinas.RealizaVenta(this.catalinas, producto, colono);
            this.comboBox1.Items.Remove(producto);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Genera un producto con los datos del combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cargo el producto
            this.producto = (Producto)comboBox1.SelectedItem;
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
                this.comboBox1.Items.Add(nuevaAntiparra.ingresante);
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
                this.comboBox1.Items.Add(nuevoGorrito.ingresante);
                MessageBox.Show("Alta exitosa");
            }

        }
    }
}

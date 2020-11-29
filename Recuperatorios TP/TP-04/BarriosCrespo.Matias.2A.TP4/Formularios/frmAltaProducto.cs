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

namespace Formularios
{
    public partial class frmAltaProducto : Form
    {
        private Colonia catalinas;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public frmAltaProducto()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que recibe un parámetro de tipo Colonia.
        /// </summary>
        /// <param name="catalinas"></param>
        public frmAltaProducto(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }
        /// <summary>
        /// Carga en el comboBox de manera Hardcodeada los dos productos que se pueden dar
        /// de alta: Gorrito y Antiparra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAltaProducto_Load(object sender, EventArgs e)
        {
            this.cmbTiposProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTiposProductos.Items.Add("Atiparras");
            this.cmbTiposProductos.Items.Add("Gorritos");
            this.cmbTiposProductos.SelectedIndex = 0;
            this.Text = "Alta productos";
        }

        /// <summary>
        /// Deriva a los formularios de alta de Gorrito y Antiparras según el índice seleccionado
        /// del ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTiposProductos.SelectedIndex == 0)
                {
                    frmAltaAntiparra nuevaAntiparra = new frmAltaAntiparra(this.catalinas);
                    nuevaAntiparra.StartPosition = FormStartPosition.CenterScreen;
                    nuevaAntiparra.ShowDialog();
                }
                else
                {
                    frmAltaGorrito nuevoGorrito = new frmAltaGorrito(this.catalinas);
                    nuevoGorrito.StartPosition = FormStartPosition.CenterScreen;
                    nuevoGorrito.ShowDialog();
                }
                this.Close();
            }
            catch (ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Establece el DialogResult en Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}

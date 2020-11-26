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

        public frmAltaProducto()
        {
            InitializeComponent();
        }

        public frmAltaProducto(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }


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

            }
            catch(ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAltaProducto_Load(object sender, EventArgs e)
        {
            this.cmbTiposProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTiposProductos.Items.Add("Atiparras");
            this.cmbTiposProductos.Items.Add("Gorritos");

            this.cmbTiposProductos.SelectedIndex = 0;

        }

    }
}

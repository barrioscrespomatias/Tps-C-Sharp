using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excepciones;
using Entidades;

namespace Formularios
{

    public partial class frmBuscarColono : Form
    {
        public int dni;
        private Colonia catalinas;

        public frmBuscarColono()
        {
            InitializeComponent();
        }

        public frmBuscarColono(Colonia catalinas):this()
        {
            this.catalinas = catalinas;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dni = Validaciones.Validar.ValidarSoloNumeros(this.txtBoxBuscarColono.Text);
            }
            catch (ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Si el dni no está en la colonia, dialog result no es ok.
            //Metodo para buscar el dni en la colonia.

            if (dni > 0 && this.catalinas == dni)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("No se encontró el DNI.");

        }
    }
}

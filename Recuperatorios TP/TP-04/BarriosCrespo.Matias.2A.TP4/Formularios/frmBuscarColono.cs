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

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmBuscarColono()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor con un parámetro que recibe una colonia.
        /// </summary>
        /// <param name="catalinas"></param>
        public frmBuscarColono(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }

        /// <summary>
        /// Busca un colono por DNI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBuscarColono_Load(object sender, EventArgs e)
        {
            this.Text = "Buscar";
        }
        /// <summary>       
        /// Toma por formulario el DNI a buscar.
        /// Valida que el dato ingresado sea correcto.        
        /// Utiliza sobrecarga == entre colonia y un dni para buscar el dni en la colonia.
        /// Si el dni no está en la colonia, no establece el DialogResult en OK.
        /// Si todo es correcto establece el dialogResult en ok.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dni = Validaciones.Validar.ValidarSoloNumeros(this.txtBoxBuscarColono.Text);
                if (dni > 0 && this.catalinas == dni)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("No se encontró el DNI.");
            }
            catch (ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}

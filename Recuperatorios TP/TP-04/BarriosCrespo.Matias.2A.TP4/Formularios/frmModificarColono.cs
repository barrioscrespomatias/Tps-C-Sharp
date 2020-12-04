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

namespace Formularios
{
    public partial class frmModificarColono : Form
    {
        Colono colono;

        /// <summary>
        /// Constructor por defecto.        
        /// </summary>
        public frmModificarColono()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor con un parámetro que recibe un colono.
        /// </summary>
        /// <param name="c"></param>
        public frmModificarColono(Colono colono) : this()
        {
            this.colono = colono;
        }
        /// <summary>
        /// Carga los comboBox de los peridodos, los meses de inscripcion y establece los indices
        /// seleccionados de los comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModificarColono_Load(object sender, EventArgs e)
        {
            foreach (string aux in Enum.GetNames(typeof(EPeriodoInscripcion)))
            {
                this.cmbPeriodo.Items.Add(aux);
            }
            foreach (string aux in Enum.GetNames(typeof(EMesIncripcion)))
            {
                this.cmbMes.Items.Add(aux);
            }
            this.ActualizarTextBox();
            this.Text = "Modificar datos";
        }

        /// <summary>
        /// Acepta el formulario. Establece el DialogResult en OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Cancela la modificación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// Actualiza los textBox con los datos del colono.
        /// </summary>
        public void ActualizarTextBox()
        {
            this.txtBoxApellido.Text = this.colono.Apellido;
            this.txtBoxNombre.Text = this.colono.Nombre;
            this.txtBoxDni.Text = this.colono.Dni.ToString();
            this.txtBoxFechaNacimiento.Text = this.colono.FechaNacimiento.ToShortDateString();
            this.cmbMes.SelectedIndex = (int)this.colono.CargarMes;
            this.cmbPeriodo.SelectedIndex = (int)this.colono.Periodo;            
        }
    }
}

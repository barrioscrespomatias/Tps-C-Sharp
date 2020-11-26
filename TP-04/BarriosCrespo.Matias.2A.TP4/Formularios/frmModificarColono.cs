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
        /// <summary>
        /// Constructor por defecto.
        /// Carga los datos en el combobox.
        /// </summary>
        public frmModificarColono()
        {
            InitializeComponent();

            foreach (string aux in Enum.GetNames(typeof(EPeriodoInscripcion)))
            {
                this.cmbPeriodo.Items.Add(aux);
            }

            foreach (string aux in Enum.GetNames(typeof(EMesIncripcion)))
            {
                this.cmbMes.Items.Add(aux);
            }
            this.cmbMes.SelectedIndex = (int)EMesIncripcion.Enero;
            this.cmbPeriodo.SelectedIndex = (int)EPeriodoInscripcion.Mes;
        }



        public string Nombre
        {
            get { return this.txtBoxNombre.Text; }
           
        }

        public string Apellido
        {
            get { return this.txtBoxApellido.Text; }
    
        }

        public string FechaNacimiento
        {
            get { return this.txtBoxFechaNacimiento.Text; }
           
        }

        public int Dni
        {
            get { return int.Parse(this.txtBoxDni.Text); }
           
        }

        public string Periodo
        {
            get { return this.cmbPeriodo.SelectedItem.ToString(); }
           
        }

        public string Mes
        {
            get { return this.cmbMes.SelectedItem.ToString(); }
            
        }



        /// <summary>
        /// Constructor con un parámetro. Obtiene los datos del colono a modificar.
        /// </summary>
        /// <param name="c"></param>
        public frmModificarColono(Colono c) : this()
        {
            this.txtBoxApellido.Text = c.Apellido;
            this.txtBoxNombre.Text = c.Nombre;
            this.txtBoxDni.Text = c.Dni.ToString();
            this.txtBoxFechaNacimiento.Text = c.FechaNacimiento.ToString();
            this.cmbMes.SelectedItem = c.CargarMes;
            this.cmbPeriodo.SelectedItem = c.Periodo;

        }
        /// <summary>
        /// Acepta el formulario. modifica el dialog result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

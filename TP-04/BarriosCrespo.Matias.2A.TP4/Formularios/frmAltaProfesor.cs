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
    public partial class frmAltaProfesor : Form
    {
        public DelegadoCargaProfesor EventoDeCarga;
        public Profesor profesor;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmAltaProfesor()
        {
            InitializeComponent();
        }

        public string Nombre
        {
            get { return this.txtBoxNombre.Text; }
            set { value = this.txtBoxNombre.Text; }
        }

        public string Apellido
        {
            get { return this.txtBoxApellido.Text; }
            set { value = this.txtBoxApellido.Text; }
        }

        public string FechaNacimiento
        {
            get { return this.txtBoxFechaNacimiento.Text; }
            set { value = this.txtBoxFechaNacimiento.Text; }
        }

        public int Dni
        {
            get { return int.Parse(this.txtBoxDni.Text); }
            set { value = int.Parse(this.txtBoxDni.Text); }
        }


        public double Sueldo
        {
            get { return double.Parse(this.txtBoxSueldo.Text); }

        }
        /// <summary>
        /// Acepta el formulario y obtiene su datos. Modifica el dialogresutl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            profesor = new Profesor(this.Nombre, this.Apellido, Convert.ToDateTime(this.FechaNacimiento), this.Dni, this.Sueldo);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

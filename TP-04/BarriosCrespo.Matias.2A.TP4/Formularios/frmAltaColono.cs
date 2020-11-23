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
    public partial class frmAltaColono : Form
    {
        public event DelegadoColono EventoCargarColono;
        public Colonia catalinas;
        /// <summary>
        /// Constructor por defecto colono.
        /// Carga los enumerados para los combobox.
        /// 
        /// </summary>
        public frmAltaColono()
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
            this.cmbMes.SelectedIndex = (int)EMesIncripcion.Diciembre;
            this.cmbPeriodo.SelectedIndex = (int)EPeriodoInscripcion.Quincena;

        }
        /// <summary>
        /// Constructor un parámetro que recibe una colonia.
        /// </summary>
        /// <param name="c1"></param>
        public frmAltaColono(Colonia c1) : this()
        {
            this.catalinas = c1;

        }
        /// <summary>
        /// Constructor que recibe un colono. Se utiliza para modificar los datos y borrar.
        /// </summary>
        /// <param name="c"></param>
        public frmAltaColono(Colono c)
        {
            this.txtBoxApellido.Text = c.Apellido;
            this.txtBoxNombre.Text = c.Nombre;
            this.txtBoxDni.Text = c.Dni.ToString();
            this.txtBoxFechaNacimiento.Text = c.FechaNacimiento.ToString();
            this.cmbMes.SelectedItem = c.CargarMes;
            this.cmbPeriodo.SelectedItem = c.CargarPeriodo;

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

        public string Periodo
        {
            get { return this.cmbPeriodo.SelectedItem.ToString(); }
            set { value = this.cmbPeriodo.SelectedItem.ToString(); }
        }

        public string Mes
        {
            get { return this.cmbMes.SelectedItem.ToString(); }
            set { value = EMesIncripcion.Enero.ToString(); }
        }
        /// <summary>
        /// Acepta el formulario de alta. Obtiene los datos del colono desde el formulario
        /// Sino se encuentra lo agrega a la colonia. Envia los datos mediante delegado  a la DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            Colono c = new Colono(this.txtBoxNombre.Text, this.txtBoxApellido.Text, Convert.ToDateTime(this.txtBoxFechaNacimiento.Text), this.Dni, EPeriodoInscripcion.Mes);

            if (this.catalinas != c)
            {
                //agrego a la colonia
                this.catalinas += c;

                //cargar colono en base datagrid.
                frmMostrarColonos mostrar = new frmMostrarColonos();
                this.EventoCargarColono += new DelegadoColono(mostrar.CargarColono);
                this.EventoCargarColono(c);
                this.DialogResult = DialogResult.OK;
            }
            else

            {
                MessageBox.Show("Ya existe un colono con el ese DNI");
            }

        }
        /// <summary>
        /// Cancela el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }
    }
}

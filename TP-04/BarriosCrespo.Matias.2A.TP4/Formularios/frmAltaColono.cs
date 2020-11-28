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
using BaseDatos;
using System.Data.Sql;
using System.Data.SqlClient;
using Validaciones;
using Excepciones;

namespace Formularios
{
    public partial class frmAltaColono : Form
    {
        public Colonia catalinas;

        private SqlConnection conexion;
        private VincularDB nuevaConexion;

        /// <summary>
        /// Constructor por defecto.         
        /// </summary>
        public frmAltaColono()
        {
            InitializeComponent();          

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
            this.cmbPeriodo.SelectedItem = c.Periodo;

        }

        /// <summary>
        /// Establece los combos a mostrar el periodo de inscripcion y el mes de inscripcion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAltaColono_Load(object sender, EventArgs e)
        {
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
        /// Toma los datos del formulario para crear un nuevo colono. 
        /// Valida que los campos sean correctos.
        /// Agrega el colono a la colonia y a la base de datos.
        /// Si todo es correcto establece el dialogResult en ok.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionDB);
            this.nuevaConexion = new VincularDB(conexion);
            Colono c = new Colono();
            try
            {
                c.Nombre = Validar.ValidarSoloLetras(this.txtBoxNombre.Text);
                c.Apellido = Validar.ValidarSoloLetras(this.txtBoxApellido.Text);
                c.Dni = Validar.ValidarSoloNumeros(this.txtBoxDni.Text);
                c.CargarMes = (EMesIncripcion)this.cmbMes.SelectedIndex;
                c.Periodo = (EPeriodoInscripcion)this.cmbPeriodo.SelectedIndex;
                c.Saldo = Colono.CalcularDeuda(c.Periodo);
                c.FechaNacimiento = Validar.ValidarFecha(this.txtBoxFechaNacimiento.Text);
                c.Edad = (int)DateTime.Now.Year - c.FechaNacimiento.Year;

            }
            catch (ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (this.catalinas != c)
            {
                if (Colono.EsValido(c))
                {
                    this.catalinas += c;
                    if (nuevaConexion.AgregarColono(c))
                    {
                        MessageBox.Show("Se ha agregado el colono a la base de datos!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                        
                    
                }
                else
                {
                    MessageBox.Show("Uno o mas campos son incorrectos");
                }
            }
            else
                MessageBox.Show("Ya existe un colono con ese DNI.");
        }
        /// <summary>
        /// Establece el dialogResult en Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

       
    }
}

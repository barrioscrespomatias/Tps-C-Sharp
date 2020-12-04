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
        /// <param name="colono"></param>
        public frmAltaColono(Colonia colono) : this()
        {
            this.catalinas = colono;
        }
        /// <summary>
        /// Constructor que recibe un colono. Se utiliza para modificar los datos y borrar.
        /// </summary>
        /// <param name="colono"></param>
        public frmAltaColono(Colono colono)
        {
            this.txtBoxApellido.Text = colono.Apellido;
            this.txtBoxNombre.Text = colono.Nombre;
            this.txtBoxDni.Text = colono.Dni.ToString();
            this.txtBoxFechaNacimiento.Text = colono.FechaNacimiento.ToString();
            this.cmbMes.SelectedItem = colono.CargarMes;
            this.cmbPeriodo.SelectedItem = colono.Periodo;

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
            this.Text = "Alta Colono";
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
            Colono colono = new Colono();
            try
            {
                colono.Nombre = Validar.ValidarSoloLetras(this.txtBoxNombre.Text);
                colono.Apellido = Validar.ValidarSoloLetras(this.txtBoxApellido.Text);
                colono.Dni = Validar.ValidarSoloNumeros(this.txtBoxDni.Text);
                colono.CargarMes = (EMesIncripcion)this.cmbMes.SelectedIndex;
                colono.Periodo = (EPeriodoInscripcion)this.cmbPeriodo.SelectedIndex;
                colono.SaldoCuota = Colono.CalcularDeuda(colono.Periodo);
                colono.FechaNacimiento = Validar.ValidarFecha(this.txtBoxFechaNacimiento.Text);
                colono.Edad = (int)DateTime.Now.Year - colono.FechaNacimiento.Year;
                colono.EdadGrupo = colono.AsignarGrupo(colono.Edad);

                if (this.catalinas != colono)
                {
                    if (Colono.EsValido(colono))
                    {
                        if (this.nuevaConexion.ProbarConexion())
                        {
                            //this.catalinas += colono;
                            if (nuevaConexion.AgregarColono(colono))
                            {
                                MessageBox.Show("Se ha agregado el colono a la base de datos!");
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido conectar a la base de datos");
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
            catch (ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NacimientoInvalidoException ex)
            {
                MessageBox.Show(ex.Message);
            }

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

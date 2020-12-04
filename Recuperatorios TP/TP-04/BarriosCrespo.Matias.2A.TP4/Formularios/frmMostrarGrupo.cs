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
using System.Data.Sql;
using System.Data.SqlClient;

namespace Formularios
{
    public partial class frmMostrarGrupo : Form
    {

        DataTable dt;
        Colonia catalinas;
        private frmPrincipal principal = new frmPrincipal();
        public event DelegadoActualizaColonia EventoActualizacion;

        /// <summary>
        /// Constructor por defecto. 
        /// </summary>
        public frmMostrarGrupo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor con un parámetro que recibe una colonia con todos sus datos.
        /// </summary>
        /// <param name="colonia"></param>
        public frmMostrarGrupo(Colonia colonia) : this()
        {
            this.catalinas = colonia;
        }
        /// <summary>
        /// Carga los grupos en el comboBox que permite seleccionar el grupo a mostrar.
        /// Configura el dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMostrarGrupo_Load(object sender, EventArgs e)
        {
            this.EventoActualizacion += new DelegadoActualizaColonia(principal.ActualizarColonia);
            this.cmbSeleccionGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ActualizarGrupos();
            //configuracion del dataGridView
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
            this.Text = "Mostrar grupo";

        }

        /// <summary>
        /// Crea filas en el dataTable cargando en cada una la informacion de un colono que pertenezca
        /// al grupo seleccionado en el comboBox.
        /// Carga el dataGridView con los valores del dataTable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //Actualiza la colonia con los últimos datos de la base de datos.
            this.catalinas = this.EventoActualizacion();

            this.dataGridView1.Columns.Clear();
            this.ConfigurarDataTable();
            foreach (Grupo aux in this.catalinas.ListaDeGrupos)
            {
                if (aux.EdadDelGrupo.ToString() == this.cmbSeleccionGrupos.SelectedItem.ToString())
                {
                    foreach (Colono colono in aux.ListadoColonos)
                    {
                        DataRow fila = this.dt.NewRow();
                        fila["nombre"] = colono.Nombre;
                        fila["apellido"] = colono.Apellido;
                        fila["dni"] = colono.Dni;
                        fila["fechaNacimiento"] = colono.FechaNacimiento;
                        fila["periodo"] = colono.Periodo;
                        fila["saldo cuota"] = colono.SaldoCuota;
                        fila["saldo productos"] = colono.SaldoProductos;
                        this.dt.Rows.Add(fila);
                    }
                }
            }
            //Carga dataGridView con los valores del dataTable.
            this.dataGridView1.DataSource = this.dt;
        }
        /// <summary>
        /// Configurar datatable.
        /// </summary>
        private void ConfigurarDataTable()
        {
            this.dt = new DataTable("Colonos");
            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("nombre", typeof(string));
            this.dt.Columns.Add("apellido", typeof(string));
            this.dt.Columns.Add("dni", typeof(int));
            this.dt.Columns.Add("fechaNacimiento", typeof(DateTime));
            this.dt.Columns.Add("periodo", typeof(string));
            this.dt.Columns.Add("saldo cuota", typeof(double));
            this.dt.Columns.Add("saldo productos", typeof(double));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        private void ActualizarGrupos()
        {
            this.cmbSeleccionGrupos.Items.Clear();
            foreach (Grupo aux in catalinas.ListaDeGrupos)
            {
                if (aux.EdadDelGrupo != EEdad.EdadIncorrecta)
                    this.cmbSeleccionGrupos.Items.Add(aux.EdadDelGrupo.ToString());
            }
            if (cmbSeleccionGrupos.Items.Count > 0)
                this.cmbSeleccionGrupos.SelectedIndex = 0;
            else
                MessageBox.Show("No hay ningun grupo cargado en la colonia!!");
        }

    }
}

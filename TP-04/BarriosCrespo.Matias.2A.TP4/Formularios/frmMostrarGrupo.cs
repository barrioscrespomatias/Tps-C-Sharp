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
        /// <summary>
        /// Constructor por defecto. 
        /// </summary>
        public frmMostrarGrupo()
        {
            InitializeComponent();
            this.cmbSeleccionGrupos.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        /// <summary>
        /// constructor con un parámetro. recibe una colonia.
        /// </summary>
        /// <param name="c1"></param>
        public frmMostrarGrupo(Colonia c1) : this()
        {
            this.catalinas = c1;
        }

        /// <summary>
        /// Carga los colonos en el visor segun su edad. De esta manera logra mostrar filtrándo por grupos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            this.ConfigurarDataTable();


            foreach (Grupo aux in this.catalinas.ListaDeGrupos)
            {
                if (aux.EdadDelGrupo.ToString() == this.cmbSeleccionGrupos.SelectedItem.ToString())
                {
                    foreach (Colono c in aux.ListadoColonos)
                    {
                        DataRow fila = this.dt.NewRow();
                        fila["nombre"] = c.Nombre;
                        fila["apellido"] = c.Apellido;
                        fila["dni"] = c.Dni;
                        fila["fechaNacimiento"] = c.FechaNacimiento;
                        fila["periodo"] = c.CargarPeriodo;
                        fila["saldo"] = c.Deuda;
                        this.dt.Rows.Add(fila);
                    }
                }
            }

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
            this.dt.Columns.Add("saldo", typeof(double));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }
        /// <summary>
        /// Load.Carga los combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMostrarGrupo_Load(object sender, EventArgs e)
        {
            foreach (Grupo aux in catalinas.ListaDeGrupos)
            {
                this.cmbSeleccionGrupos.Items.Add(aux.EdadDelGrupo.ToString());
            }
            this.cmbSeleccionGrupos.SelectedIndex = 0;
        }
    }
}

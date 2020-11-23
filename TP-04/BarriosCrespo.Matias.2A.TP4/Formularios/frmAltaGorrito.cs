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
using Stock;

namespace Formularios
{
    public partial class frmAltaGorrito : Form
    {
        public Colonia catalinas;
        public Gorrito ingresante;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmAltaGorrito()
        {
            InitializeComponent();
        }
        /// <summary>
        /// COnstructor un parámetro que recibe una colonia.
        /// </summary>
        /// <param name="catalinas"></param>
        public frmAltaGorrito(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }

        /// <summary>
        /// Carga los combobox. Hardcodeo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAltaGorrito_Load(object sender, EventArgs e)
        {
            this.cmbColores.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbColores.Items.Add(ConsoleColor.Red);
            this.cmbColores.Items.Add(ConsoleColor.Green);
            this.cmbColores.Items.Add(ConsoleColor.Blue);

        }
        /// <summary>
        /// Acepta el alta del gorrito. Obtiene sus datos desde formulario, agrega el gorrito a la 
        /// colonia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {

            ConsoleColor color = (ConsoleColor)this.cmbColores.SelectedItem;
            double precio = double.Parse(this.textBoxPrecio.Text);

            ingresante = new Gorrito(color, precio);
            this.catalinas.ProductosEnVenta.Listado.Add(ingresante);
            this.DialogResult = DialogResult.OK;
        }
    }
}

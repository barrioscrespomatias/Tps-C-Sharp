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
    public partial class frmAltaAntiparra : Form
    {
        public Colonia catalinas;
        public Antiparra ingresante;
        /// <summary>
        /// Construcotor por defecto.
        /// </summary>
        public frmAltaAntiparra()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que recibe un parámetro de tipo colonia.
        /// </summary>
        /// <param name="catalinas"></param>
        public frmAltaAntiparra(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }
        /// <summary>
        /// Acepta el alta de la antiparra. Hardcodea la marca, el resto de los datos los toma
        /// por formulaio. Crea el producto y lo  ingresa a la colonia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {
            EMarca marca = EMarca.Pirulito;
            ConsoleColor color = (ConsoleColor)this.cmbBoxColores.SelectedItem;
            double precio = double.Parse(this.txtBoxPrecio.Text);

            ingresante = new Antiparra(marca, color, precio);
            this.catalinas.ProductosEnVenta.Listado.Add(ingresante);
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Carga previamente los datos de los combobox. Hardcodeo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAltaAntiparra_Load(object sender, EventArgs e)
        {
            this.cmbBoxColores.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBoxColores.Items.Add(ConsoleColor.Red);
            this.cmbBoxColores.Items.Add(ConsoleColor.Green);
            this.cmbBoxColores.Items.Add(ConsoleColor.Blue);
            this.cmbBoxMarca.Items.Add(EMarca.Adidas);
            this.cmbBoxMarca.Items.Add(EMarca.Pirulito);
            this.cmbBoxMarca.Items.Add(EMarca.Speedo);
        }
    }
}

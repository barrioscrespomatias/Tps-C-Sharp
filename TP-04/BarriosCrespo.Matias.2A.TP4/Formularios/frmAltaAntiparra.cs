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
using Excepciones;

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
            this.cmbBoxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBoxColores.DropDownStyle = ComboBoxStyle.DropDownList;

            EMarca marca = (EMarca)this.cmbBoxMarca.SelectedIndex;
            EColores color = (EColores)this.cmbBoxColores.SelectedIndex;
            try
            {
                double precio = Validaciones.Validar.ValidarSoloNumeros(this.txtBoxPrecio.Text);
                ingresante = new Antiparra(marca, color, precio);
                this.catalinas.AumentarStock(this.catalinas, ingresante, 1);
                this.DialogResult = DialogResult.OK;
            }
            catch(ValidacionIncorrectaException ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            

            ///Error al cargar el producto. No agrega a la colonia

            
        }
        /// <summary>
        /// Carga previamente los datos de los combobox. Hardcodeo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAltaAntiparra_Load(object sender, EventArgs e)
        {
            this.cmbBoxColores.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (EColores color in Enum.GetValues(typeof(EColores)))
            {
                this.cmbBoxColores.Items.Add(color.ToString());
            }

            foreach (EMarca marca in Enum.GetValues(typeof(EMarca)))
            {
                this.cmbBoxMarca.Items.Add(marca.ToString());
            }

            this.cmbBoxColores.SelectedIndex = 0;
            this.cmbBoxMarca.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

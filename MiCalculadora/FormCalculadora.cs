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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            this.Text = "Calculadora de Barrios Crespo Matias del curso 2°A";
            this.lblResultado.Text = "";

            //Cargar el ComboBox
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");

            this.CenterToScreen();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        #region metodos
        /// <summary>
        /// Limpia los valores de los numeros ingresados, el operador y el resultado.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }
        /// <summary>
        /// Realiza la operacion entre dos números ingresados por el usuario. Llama a la funciona estática
        /// Calculadora.Operar().
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Si los numeros son correctos, deuelve su resultado sino, -1</returns>
        private double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero();
            Numero numeroDos = new Numero();

            double retorno = -1;
            if (this.cmbOperador.SelectedIndex == 0)
            {
                operador = "+";
            }
            numero1 = this.txtNumero1.Text;
            numero2 = this.txtNumero2.Text;
            if (numero1.Length > 0 && numero2.Length > 0)
            {
                numeroUno.SetNumero = numero1;
                numeroDos.SetNumero = numero2;
                retorno = Calculadora.Operar(numeroUno, numeroDos, operador);
            }
            return retorno;
        }
      
        #endregion

        #region capturador de eventos
        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Llama al méotod Limpiar() y borra los datos ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        } 
        /// <summary>
        /// Da valor al label del resultado llamando al metodo Operar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numeroUno = new Numero();
            Numero numeroDos = new Numero();

            this.lblResultado.Text = this.Operar(numeroUno.ToString(), numeroDos.ToString(), this.cmbOperador.Text).ToString();
            if (this.lblResultado.Text == "-1")
                this.lblResultado.Text = "Error!";
        }
        /// <summary>
        /// Dá valor al label resultado, llamando al método DecimalBinario().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero unNumero = new Numero();
            this.lblResultado.Text = unNumero.DecimalBinario(this.lblResultado.Text);
        }
        /// <summary>
        /// /// Dá valor al label resultado, llamando al método DecimalBinario().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero unNumero = new Numero();
            this.lblResultado.Text = unNumero.BinarioDecimal(this.lblResultado.Text);

        }
        #endregion
    }
}

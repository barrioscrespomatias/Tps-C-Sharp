using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region propiedades
        /// <summary>
        /// Setea el valor de la variable privada numero.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor. Asigna el valor cero al atributo numero.
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// Constructor Asigna al atributo numero el double recibido por parámetro.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor con un parametro. Asigna al atributo numero, el valor ingresado por usuario.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero) : this(double.Parse(strNumero))
        {

        }
        #endregion

        #region métodos
        /// <summary>
        /// Valida que un string pasado por parametro, sea un numero..
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Si es correcto retorna el numero en formato double, sino devuelve 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;
            double.TryParse(strNumero, out numero);
            return numero;
        }
        /// <summary>
        /// Analiza si el string contiene ceros y unos.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Si son todos 0 y 1 retorna true. Sino false.</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            int flag = 0;
            foreach (char item in binario)
            {
                if (item == '0' || item == '1' && flag == 0)
                    retorno = true;
                else
                {
                    flag = 1;
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna el binario en Decimal como string</returns>
        public string BinarioDecimal(string binario)
        {
            bool esBinario;
            //StringBuilder retorno = new StringBuilder();
            string retorno = "";

            esBinario = EsBinario(binario);
            if (esBinario)
            {
                double entero = 0;
                int potencia;
                double acumulador = 0;
                double potenciaBaseDos = 1;
                int potenciada = (int)potenciaBaseDos * 2;
                int enNumero;
                StringBuilder convertida = new StringBuilder();
                //Doy vuelta el número binario asi comienzo desde el principio a "potenciar".
                convertida.AppendFormat(Numero.Invertir(binario));
                entero = double.Parse(convertida.ToString());
                for (int i = 0; i < convertida.Length; i++)
                {
                    //Todas las potencias de 2.
                    potencia = (int)(Math.Pow(2, i));
                    //Obtengo el Char de la stringbuilder convertida.
                    char intEnChar = convertida[i];
                    //parseo el char a un entero.
                    enNumero = int.Parse(intEnChar.ToString());
                    //Acumulo el valor del numero decimal.
                    acumulador += enNumero * potencia;
                }
                Console.WriteLine(acumulador);

                retorno += acumulador.ToString();
            }
            else
                retorno = "Valor inválido";

            return retorno;
        }
        /// <summary>
        /// Convierte un numero decimal a binario. 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna un string con el numero en binario.</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(Convert.ToString(numero));
        }

        /// <summary>
        /// Convierte un numero Decimal a Binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el binario obtenido en formato string</returns>
        public string DecimalBinario(string numero)
        {
            StringBuilder cadenaBinaria = new StringBuilder();
            StringBuilder cadenaInvertida = new StringBuilder();

            int contador = 1;
            int resultado;
            int resto;
            int i;
            bool esConvertible;
            double stringNumerico = 0;

            //Verificar que el numero No sea negativo, en caso de serlo, elimino el primer caracter
            //para dejar su valor absoluto
            if (numero[0] == '-')
            {
                numero = numero.Replace("-", string.Empty);
            }
            esConvertible = double.TryParse(numero, out stringNumerico);

            if (esConvertible)
            {
                do
                {
                    resto = (int)stringNumerico % 2;
                    resultado = (int)stringNumerico / 2;
                    stringNumerico = resultado;
                    cadenaBinaria.AppendFormat(resto.ToString());
                    contador++;
                } while (resultado >= 1);
                string cadenaString = cadenaBinaria.ToString();
                //invertir cadena
                for (i = cadenaString.Length - 1; i > -1; i--)
                {
                    cadenaInvertida.AppendFormat(Convert.ToString(cadenaString[i]));
                }
            }
            else
                cadenaInvertida.AppendFormat("Valor inválido");


            return cadenaInvertida.ToString();
        }
        #endregion

        #region sobrecarga operadores
        /// <summary>
        /// Sobrecarga operador "-". Comprueba que no sean nulos y realiza la resta.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = -1;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                retorno = n1.numero - n2.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga operador "*". Comprueba que no sean nulos y realiza la multiplicacion.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = -1;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                retorno = n1.numero * n2.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga operador "/". Comprueba que no sean nulos y realiza la division.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = -1;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                if (n2.numero == 0)
                {
                    retorno = double.MinValue;
                }
                else
                    retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga operador "+". Comprueba que no sean nulos y realiza la suma.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = -1;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                retorno = n1.numero + n2.numero;
            }
            return retorno;
        }
        #endregion

        #region metodos extras
        private static string Invertir(string cad)
        {
            int i;
            StringBuilder invertida = new StringBuilder();
            for (i = cad.Length - 1; i > -1; i--)
            {
                invertida.AppendFormat(Convert.ToString(cad[i]));
            }
            return invertida.ToString();
        }
        #endregion
    }
}

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


        /// <summary>
        /// Constructor por defecto. Asigna "0" al valor del atributo this.numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        private string SetNumero
        {            
            set
            {
               this.numero =ValidarNumero(value) ;
                
            }
           
        }




        /// <summary>
        /// Valida que los elmentos de una cadena sean numericos. Caso correcto, devuelve el numero.
        /// </summary>
        /// <param name="strNumero">Cadena a verificar la validacion</param>
        /// <returns>Si se logra validar, retorna el numero; caso contrario, devuelve 0.</returns>
        private double ValidarNumero(string strNumero)
        {

            double auxiliar = 0;
            double.TryParse(strNumero, out auxiliar);
            return auxiliar;

        }




        /// <summary>
        /// Constructor explicito con un double como parametro(numero). 
        /// </summary>
        /// <param name="numero">Parametro pasado al constructor.</param>

        public Numero(double numero)
        {
            this.SetNumero = numero.ToString(); 
        }



        ///// <summary>
        ///// Constructor explicito con un string como parametro.
        ///// </summary>
        ///// <param name="strNumero">String pasado como parametro.</param>
        //public Numero(string strNumero)
        //{
        //    this.numero = ValidarNumero(strNumero);
        //}




        /// <summary>
        /// Sobrecarga Operador "-". Si los numeros son distintos de null, los resta y devuelve el resultado. 
        /// </summary>
        /// <param name="n1">Instancia de clase Numero</param>
        /// <param name="n2">Instancia de clase Numero</param>
        /// <returns>Retorna -1 en caso de Error. Sino el resultado de la resta.</returns>
        public static double operator -(Numero n1, Numero n2)
        {          

            double auxiliar = -1;
            if(!object.Equals(n1,null) && !object.Equals(n2,null))
            {               

                auxiliar = n1.numero - n2.numero;
            }
            
            return auxiliar;
        }



        /// <summary>
        /// Sobrecarga Operador "+". Si los numeros son distintos de null, los suma y devuelve el resultado.
        /// </summary>
        /// <param name="n1">Instancia de clase Numero</param>
        /// <param name="n2">Instancia de clase Numero</param>
        /// <returns>Retorna -1 en caso de Error. Sino el resultado de la suma.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double auxiliar = -1;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {

                auxiliar = n1.numero + n2.numero;
            }

            return auxiliar;

        }


        /// <summary>
        /// Sobrecarga Operador "/". Si los numeros son distintos de null, los divide y devuelve el resultado.
        /// </summary>
        /// <param name="n1">Instancia de clase Numero</param>
        /// <param name="n2">Instancia de clase Numero</param>
        /// <returns>Retorna -1 en caso de Error. Sino el resultado de la division.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double auxiliar = double.MinValue;
            if (!object.Equals(n1,null) && !object.Equals(n2, null))
            {
                if(n2.numero!=0)
                {
                    auxiliar = n1.numero / n2.numero;
                }
                
                
            }

            return auxiliar;

        }


        /// <summary>
        /// Sobrecarga Operador "*". Si los numeros son distintos de null, los multiplica y devuelve el resultado.
        /// </summary>
        /// <param name="n1">Instancia de clase Numero</param>
        /// <param name="n2">Instancia de clase Numero</param>
        /// <returns>Retorna -1 en caso de Error. Sino el resultado de la multiplicacion.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double auxiliar = -1;
            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {

                auxiliar = n1.numero*n2.numero;
            }

            return auxiliar;

        }
        /// <summary>
        /// Convierte un numero Decimal a Binario. Devuelve el mismo en string.
        /// </summary>
        /// <param name="numeroIngresado">Numero (double) a convertir</param>
        /// <returns>Retorna el numero binario como string. </returns>
         public string DecimalBinario(double numero)
        {

            string bufferRetorno = "";

            ///VARIABLES PARA CALCULO
            double resultado;
            int modulo;
            int bandera = 0;
            int posicion;
            string invertida = "";

            if(numero == 0)
            {
                invertida = numero.ToString();
            }

            else
            {
                if(numero<0)
                {
                    numero *= -1;
                }

                resultado = numero;

                while (bandera == 0 && resultado >= 1)
                {
                    modulo = (int)numero % 2;
                    resultado = numero / 2;
                    numero = resultado;
                    bufferRetorno = bufferRetorno + modulo.ToString();
                    bandera = 0;
                }


                ///INVERTIR OPERACION
                posicion = bufferRetorno.Length;

                while (posicion > 0)
                {
                    invertida = invertida + bufferRetorno.Substring(posicion - 1, 1);
                    posicion -= 1;

                }

            }
            

            return invertida;
        }



        /// <summary>
        /// Convierte un numero Decimal a Binario. Devuelve el mismo en string.
        /// </summary>
        /// <param name="numero">Numero (string) a convertir en binario.</param>
        /// <returns>Retorna el numero binario en string.</returns>



        public string DecimalBinario(string numero)
        {
            //string buffer;
            double salida = 0;
            double.TryParse(numero, out salida);


            //buffer = this.DecimalBinario(numero);

            if(salida == 0)
            {
                return "Valor invalido";
            }            

            return this.DecimalBinario(salida);//buffer;


        }

        /// <summary>
        ///  Convierte un numero Binario a Decimal. Devuelve el mismo en tipo double.
        /// </summary>
        /// <param name="binario">Numero binario a convertir(string)</param>
        /// <returns>Retorna el numero convertido a decimal.</returns>
        public double BinarioDecimal(string binario)
        {
            int i;            
            char[] buffer;
            buffer = new char[binario.Length];            
            int posicion = 0;           
            double acumulador = 0;

            buffer = binario.ToCharArray();
            posicion = buffer.Length;

            for (i = 0;i<buffer.Length;i++)
            {
                posicion--;
                if (buffer[i].ToString() == "1")
                {                    
                    acumulador += Math.Pow(2, posicion);                    
                }

                else if(buffer[i].ToString() != "1" && buffer[i].ToString() != "0")
                {
                    acumulador = -1;
                }
            }
            return acumulador;
        }

    }
}

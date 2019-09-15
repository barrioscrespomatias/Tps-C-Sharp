using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Realiza las operaciones entre dos atributos de tipo numero. Utiliza sobrecargas de "+,-,*,/".
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador"></param>
        /// <returns>Retorna -1 en caso de error o el resultado de la operacion.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double aux = -1;
            string operadorAux;           

            operadorAux = ValidarOperador(operador);

            switch(operadorAux)
            {
                case "/":
                    {
                        aux = num1 / num2;
                        break;
                    }
                case "*":
                    {
                        aux = num1 * num2;
                        break;
                    }

                case "+":
                    {
                        aux = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        aux = num1 - num2;
                        break;
                    }
            }           

            return aux;
        }


        /// <summary>
        /// Valida que el operador recibido sea "+", "-", "/", "*". Caso contrario devuelve "+"; 
        /// </summary>
        /// <param name="operador">Operador ingresado.</param>
        /// <returns>Retorna el operador validado.</returns>
        private static string ValidarOperador(string operador)
        {
            int flag = 0;

            while(flag == 0)
            {
                switch(operador)
                {
                    case "-":
                        {
                            operador = "-";
                            break;
                        }
                    case "/":
                        {
                            operador = "/";
                            break;
                        }
                    case "*":
                        {
                            operador = "*";
                            break;
                        }
                    default:
                        {
                            operador = "+";
                            break;
                        }
                }

                flag = 1;
            }           

            return operador;
        }
            
    }
}

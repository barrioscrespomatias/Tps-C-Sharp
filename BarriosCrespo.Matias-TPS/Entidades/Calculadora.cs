using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        //public static double Operar(Numero num1, Numero num2, string operador)
        //{


        //}


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo;
            
            try
            {
                
                if(File.Exists(ruta))
                {
                    using (StreamWriter swtr = new StreamWriter(ruta, true))
                    swtr.WriteLine(texto);
                    
                }
                else
                {
                    using (StreamWriter swtr = new StreamWriter(ruta, false))
                    swtr.WriteLine(texto);
                    
                }
                retorno = true;
                                
            }
            catch(Exception e)
            {
                retorno = false;
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            return retorno;
        }
    }
}

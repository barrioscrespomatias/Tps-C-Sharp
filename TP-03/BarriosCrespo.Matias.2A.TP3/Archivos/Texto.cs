using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            Encoding miCodificacion = Encoding.UTF8;
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true, miCodificacion))
                {
                    sw.WriteLine(datos.ToString());
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = null;
            Encoding miCodificacion = Encoding.UTF8;
            string lectura = "";
            using (StreamReader sr = new StreamReader(archivo, miCodificacion))
            {
                //Debería hacer un Console.WriteLine
                lectura = sr.ReadToEnd();
                Console.WriteLine(lectura);
                retorno = true;
            }
            return retorno;

        }
    }
}

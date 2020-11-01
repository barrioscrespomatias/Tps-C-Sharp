using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si pudo escribir, sino false.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            Encoding miCodificacion = Encoding.UTF8;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, miCodificacion))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }
            return retorno;
        }
        /// <summary>
        /// Lee los datos desde un archivo XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si pudo leer, sino false.</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default(T);
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = ((T)ser.Deserialize(reader));
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }
            return retorno;

        }
    }
}

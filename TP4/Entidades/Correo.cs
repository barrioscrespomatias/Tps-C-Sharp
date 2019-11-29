using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;        
       
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();

        }

        #region propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #endregion

        #region metodos

        /// <summary>
        /// Finaliza los hilos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilosActivos in this.mockPaquetes)
            {
                hilosActivos.Abort();
            }

        }
        /// <summary>
        /// Muestras los datos de correo.paquetes.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete aux in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega, aux.Estado.ToString()));
            }
            return sb.ToString();
        }

        #endregion

        #region sobrecarga operadores
        /// <summary>
        /// Sobrecarga "+". Introduce paquete en correo.paquetes.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {          
            foreach (Paquete aux in c.paquetes)
            {                
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException("El Trackin ID "+p.TrackingID+" ya se figura en la lista de envios");                   
                }               
            }
            c.paquetes.Add(p);
            Thread hiloPaquete = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hiloPaquete);
            hiloPaquete.Start();
            return c;
        }
        #endregion
    }
}

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

        // public  List<Paquete> Paquetes { get; set; }

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

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();

        }

        public void FinEntregas()
        {
            foreach (Thread hilosActivos in this.mockPaquetes)
            {
                hilosActivos.Abort();
            }

        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete aux in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega, aux.Estado.ToString()));

            }
            return sb.ToString();


        }

        public static Correo operator +(Correo c, Paquete p)
        {
            //Dudas en el alcance del foreach
            foreach (Paquete aux in c.paquetes)
            {
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en el correo");

                }
            }


            c.paquetes.Add(p);
            Thread hiloPaquete = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hiloPaquete);
            hiloPaquete.Start();



            return c;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            comando = new SqlCommand();            
            conexion = new SqlConnection(Properties.Settings.Default.conexion);
            comando.Connection = conexion;
        }

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                comando.CommandText = string.Format("INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) values ('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Barrios Crespo Matias')");
                comando.CommandType = CommandType.Text;
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch(Exception e)
            {                
                throw e;                
            }
            finally
            {
                conexion.Close();                
            }

            return retorno;
        }


    }
}

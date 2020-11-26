using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;
using Excepciones;

namespace BaseDatos
{
    public class VincularDB
    {

        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        public VincularDB(SqlConnection cn)
        {
            this.conexion = cn;
        }

        public bool ProbarConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                Console.WriteLine("Se ha logrado conexion!");
            }
            catch (Exception)
            {
                throw new ErrorDeConexionException("No se ha logrado conexion con la base de datos");
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    this.conexion.Close();
            }
            return retorno;

        }




        /// <summary>
        /// Carga los grupos a la colonia desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public Colonia ObtenerColonos(Colonia catalinas)
        {


            string sql = "SELECT * FROM colonos_table";

            this.comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.conexionDB);

            try
            {
                this.comando.Connection = conexion;
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = sql;

                conexion.Open();
                lector = comando.ExecuteReader();


                Colono c;
                string nombre;
                string apellido;
                int dni;
                DateTime fechaNacimiento;
                string periodo;
                double saldo;

                while (lector.Read())
                {
                    nombre = lector.GetString(1);
                    apellido = lector.GetString(2);
                    dni = lector.GetInt32(3);
                    fechaNacimiento = lector.GetDateTime(4);
                    periodo = lector.GetString(5);
                    saldo = lector.GetDouble(6);


                    //MODFICIAR PERIODO
                    c = new Colono(nombre, apellido, fechaNacimiento, dni, EPeriodoInscripcion.Mes,saldo);
                    if (catalinas != c)
                        catalinas += c;
                }

            }
            catch (Exception e)
            {
                throw new ErrorDeConexionException("Error en la conexion a la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return catalinas;
        }

        public bool AgregarColono(Colono colono)
        {
            bool retorno = false;
            string sql = "INSERT INTO colonos_table(nombre, apellido, dni, fechaNacimiento, periodo, saldo) ";
            sql += "VALUES (@nombre,@apellido,@dni,@fechaNacimiento,@periodo,@saldo)";


            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = conexion;

                this.comando.Parameters.AddWithValue("@nombre", colono.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", colono.Apellido);
                this.comando.Parameters.AddWithValue("@dni", colono.Dni);
                this.comando.Parameters.AddWithValue("@fechaNacimiento", colono.FechaNacimiento);
                this.comando.Parameters.AddWithValue("@periodo", colono.Periodo);
                this.comando.Parameters.AddWithValue("@saldo", colono.Saldo);

                this.comando.CommandText = sql;
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    retorno = true;                    
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                retorno = false;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return retorno;
        }

        public bool ModificarColono(Colono colono)
        {
            bool retorno = false;
            string sql = "UPDATE colonos_table SET nombre=@nombre, apellido=@apellido," +
                " dni=@dni, fechaNacimiento=@fechaNacimiento, periodo=@periodo, saldo=@saldo WHERE dni=@dni";



            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = conexion;

                this.comando.Parameters.AddWithValue("@nombre", colono.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", colono.Apellido);
                this.comando.Parameters.AddWithValue("@dni", colono.Dni);
                this.comando.Parameters.AddWithValue("@fechaNacimiento", colono.FechaNacimiento);
                this.comando.Parameters.AddWithValue("@periodo", colono.Periodo);
                this.comando.Parameters.AddWithValue("@saldo", colono.Saldo);


                this.comando.CommandText = sql;
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    retorno = true;
                    Console.WriteLine("Se ha actualizado la base de datos");

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                retorno = false;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return retorno;
        }

        public bool EliminarColono(Colono colono)
        {
            bool retorno = false;
            string sql = "DELETE FROM colonos_table WHERE dni=@dni";



            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = conexion;

                this.comando.Parameters.AddWithValue("@dni", colono.Dni);

                this.comando.CommandText = sql;
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    retorno = true;
                    Console.WriteLine("Se ha eliminado de la base de datos");

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                retorno = false;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return retorno;
        }


    }
}

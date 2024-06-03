using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Data;

namespace negocio
{
    public class AccesoDB
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDB()
        {
            conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CONSULTORIODB;" + "Integrated Security=True");
            comando = new SqlCommand();
        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setearQuerySP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        public void setearParametro(string nombre, object valor)
        {
            if(valor == null)
            comando.Parameters.AddWithValue(nombre, DBNull.Value);
            else
                comando.Parameters.AddWithValue(nombre, valor);
        }
        public void ejectuarLectura()
        {
            Seguridad seguridad = new Seguridad();
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
        }

        public void ejecutarAccion()
        {
            Seguridad seguridad = new Seguridad();
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
        }

        public int ejecutarAccionScalar()
        {
            Seguridad seguridad = new Seguridad();
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                seguridad.ManejarExcepcion(ex, HttpContext.Current);
                return -1;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        public void setearParametroSalida(string nombre, SqlDbType tipo)
        {
            comando.Parameters.Add(new SqlParameter(nombre, tipo) { Direction = ParameterDirection.Output });
        }
        public object obtenerParametroSalida(string nombre)
        {
            return comando.Parameters[nombre].Value;
        }
    }

}

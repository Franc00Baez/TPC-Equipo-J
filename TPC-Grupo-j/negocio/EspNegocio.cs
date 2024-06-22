using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EspNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearQuery("select id, especialidad_name FROM ESPECIALIDADES");
                accesoDB.ejectuarLectura();

                while (accesoDB.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.id = accesoDB.Lector.GetInt32(0);
                    aux.nombre = accesoDB.Lector.GetString(1);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                Seguridad.ManejarExcepcion(ex, System.Web.HttpContext.Current);
                return lista;
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }

        public bool AgregarEspecialidad(string nueva)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearQuerySP("sp_InsertarEspecialidad");
                datos.setearParametro("@especialidad_name", nueva);
                datos.setearParametroSalida("@resultado", System.Data.SqlDbType.Bit);

                datos.ejecutarAccion();

                return (bool)datos.obtenerParametroSalida("@resultado");

            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, System.Web.HttpContext.Current);
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Especialidad ObtenerEspecialidadPorId(int especialidadId)
        {
            AccesoDB datos = new AccesoDB();
            Especialidad especialidad = new Especialidad();

            try
            {
                datos.setearQuery("select id, especialidad_name FROM ESPECIALIDADES WHERE id = @id");
                datos.setearParametro("@id", especialidadId);

                datos.ejectuarLectura();

                if(datos.Lector.Read())
                {
                    especialidad.id = (int)datos.Lector["id"];
                    especialidad.nombre = datos.Lector["especialidad_name"].ToString();

                    return especialidad;
                }

                return especialidad;

            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, System.Web.HttpContext.Current);
                return especialidad;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

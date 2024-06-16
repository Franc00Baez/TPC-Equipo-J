using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using dominio;

namespace negocio
{
    public class RecNegocio
    {
        public void actualizar(Recepcionista recepcionista)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuerySP("sp_ActualizarUsuarioYRecepcionista");
                datos.setearParametro("@id", recepcionista.id);
                datos.setearParametro("@email", recepcionista.email);
                datos.setearParametro("@pass", recepcionista.password_hash);
                datos.setearParametro("@img_Url", recepcionista.img_url);
                datos.setearParametro("@idRol", (int)recepcionista.rol_type);
                datos.setearParametro("@activo", recepcionista.activo);
                datos.setearParametro("@nombre", recepcionista.nombre);
                datos.setearParametro("@apellido", recepcionista.apellido);
                datos.setearParametro("@nacimiento", recepcionista.nacimiento);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void registrarRecepcionista(Usuario user)
        {
            AccesoDB datos = new AccesoDB();
            Recepcionista nuevo = new Recepcionista(user);
            try
            {
                datos.setearQuerySP("sp_InsertarRecepcionista");
                datos.setearParametro("@usuario_id", user.id);
                datos.setearParametro("@nombre", DBNull.Value);
                datos.setearParametro("@apellido", DBNull.Value);
                datos.setearParametro("@nacimiento", DBNull.Value);

                datos.ejecutarAccion();
            }catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);

            }finally
            {
                datos.cerrarConexion();
            }
        }
        public void registrarRecepcionista(Recepcionista nuevo)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuerySP("sp_InsertarRecepcionista");
                datos.setearParametro("@usuario_id", nuevo.id);
                datos.setearParametro("@nombre", nuevo.nombre);
                datos.setearParametro("@apellido", nuevo.apellido);
                datos.setearParametro("@nacimiento", nuevo.nacimiento);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);

            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Recepcionista buscarRecepcionista(Usuario user)
        {
            AccesoDB datos = new AccesoDB();
            Recepcionista recepcionista = new Recepcionista(user);
            try
            {
                datos.setearQuerySP("sp_BuscarRecepcionistaPorUsuarioID");
                datos.setearParametro("@usuario_id", user.id);
                datos.ejectuarLectura();
                if(datos.Lector.Read())
                {
                    recepcionista.id = (int)datos.Lector["id"];
                    recepcionista.nombre = datos.Lector["nombre"] != DBNull.Value ? datos.Lector["nombre"].ToString() : "";
                    recepcionista.apellido = datos.Lector["apellido"] != DBNull.Value ? datos.Lector["apellido"].ToString() : "";
                    recepcionista.nacimiento = datos.Lector["nacimiento"] != DBNull.Value ? (DateTime)datos.Lector["nacimiento"] : DateTime.MinValue;

                    return recepcionista;

                }
                recepcionista.id = -1;
                return recepcionista;

            }catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                recepcionista.id = -1;
                return recepcionista;
            }finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

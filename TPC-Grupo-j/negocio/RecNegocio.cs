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
                    recepcionista.apellido = datos.Lector["apellido"] != DBNull.Value ? datos.Lector["nombre"].ToString() : "";
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

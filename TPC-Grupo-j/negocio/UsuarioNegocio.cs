using dominio;
using helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        /*
         ID
         EMAIL
         PASS
         IMG
         IDROL
         Fecha
         */

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuerySP("insertarNuevo");
                accesoDB.setearParametro("@email",nuevo.email);
                accesoDB.setearParametro("@password_hash", nuevo.password_hash);
                accesoDB.setearParametro("@img_url", nuevo.img_url);
                accesoDB.setearParametro("@fecha_creacion",nuevo.fecha_creacion);
                return accesoDB.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
            return 0;
        }

        public bool Login(Usuario usuario)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuery("Select id, email, password_hash,img_url,id_rol,fecha_creacion from USUARIOS Where email = @email AND password_hash = @pass");
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@pass", usuario.password_hash);
                datos.ejectuarLectura();
                if (datos.Lector.Read())
                {
                    usuario.id = (int)datos.Lector["id"];
                    usuario.rol_type =(UserRole)datos.Lector["id_rol"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                        usuario.img_url = (string)datos.Lector["img_url"];
                    if (!(datos.Lector["fechaNacimiento"] is DBNull))
                        usuario.fecha_creacion = DateTime.Parse(datos.Lector["fecha_creacion"].ToString());

                    return true;
                }
                return false;

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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using helpers;

namespace negocio
{
    public class Login
    {
        private Usuario usuario = new Usuario();
        private HashService service = new HashService();

        public int ValidarUsuario(string email, string password_hash)
        {
            AccesoDB datos = new AccesoDB();
            try
            {

                datos.setearQuerySP("sp_ValidarUsuario");
                datos.setearParametro("@email", email);
                datos.setearParametro("@password_hash", password_hash);
                datos.ejectuarLectura();

                if (datos.Lector.Read())
                {
                    int id = (int)datos.Lector["id"];
                    return id;
                }

                return -1;

            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.ToString());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool Registrar(Usuario nuevo)
        {
            AccesoDB datos = new AccesoDB();
            string passwordhash = service.HashPassword(nuevo.password_hash);
            try
            {
                datos.setearQuerySP("sp_RegistrarUsuario");


                datos.setearParametro("@email", nuevo.email);
                datos.setearParametro("@password_hash", passwordhash);
                datos.setearParametro("@img_url", nuevo.img_url);
                datos.setearParametro("@id_rol", (int)nuevo.rol_type);
                datos.setearParametro("@fecha_creacion", DateTime.Now);

                datos.setearParametroSalida("@Registrado", System.Data.SqlDbType.Bit);

                datos.ejecutarAccion();

                return (bool)datos.obtenerParametroSalida("@Registrado");

            }catch (Exception ex)
            {
                throw new Exception("Error" + ex.ToString());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

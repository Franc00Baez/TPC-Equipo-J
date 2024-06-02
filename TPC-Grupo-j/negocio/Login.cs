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

        public int ValidarUsuario(string email, string password)
        {
            AccesoDB datos = new AccesoDB();
            HashService service = new HashService();
            try
            {

                datos.setearQuerySP("sp_ObtenerUsuarioPorEmail");
                datos.setearParametro("@Email", email);
                datos.ejectuarLectura();

                if (datos.Lector.Read())
                {
                    string storedHash = datos.Lector["password_hash"].ToString();
                    int id = (int)datos.Lector["id"];
                    if (service.VerifyPassword(password, storedHash))
                    {
                        return id;
                    }
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
                datos.setearParametro("@img_url", string.IsNullOrEmpty(usuario.img_url) ? (object)DBNull.Value : usuario.img_url);
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

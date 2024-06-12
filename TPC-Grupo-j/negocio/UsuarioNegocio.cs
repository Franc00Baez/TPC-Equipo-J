using dominio;
using helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearQuery("SELECT id, email, password_hash, id_rol, img_url, fecha_creacion, activo FROM USUARIOS");
                accesoDB.ejectuarLectura();

                while (accesoDB.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.id = accesoDB.Lector.GetInt32(0);
                    aux.email = accesoDB.Lector.IsDBNull(1) ? string.Empty : accesoDB.Lector.GetString(1);
                    aux.password_hash = accesoDB.Lector.IsDBNull(2) ? string.Empty : accesoDB.Lector.GetString(2);
                    aux.rol_type = (UserRole)accesoDB.Lector.GetInt32(3);
                    aux.img_url = accesoDB.Lector.IsDBNull(4) ? string.Empty : accesoDB.Lector.GetString(4);
                    aux.fecha_creacion = accesoDB.Lector.GetDateTime(5);
                    aux.activo = accesoDB.Lector.GetBoolean(6);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la DB: " + ex.Message);
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuerySP("sp_InsertarNuevo");
                accesoDB.setearParametro("@email",nuevo.email);
                accesoDB.setearParametro("@password_hash", nuevo.password_hash);
                accesoDB.setearParametro("@img_url", nuevo.img_url);
                accesoDB.setearParametro("@fecha_creacion",nuevo.fecha_creacion);
                accesoDB.setearParametro("@activo", 1);
                return accesoDB.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
            return 0;
        }

        public void actualizar( Usuario usuario)
        {
                AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuery("Update USUARIOS set img_url = @imagen WHERE id = @id");
                accesoDB.setearParametro("@imagen", usuario.img_url);
                accesoDB.setearParametro("@id", usuario.id);
                accesoDB.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }
        
        public Usuario BuscarUsuarioPorId(int id)
        {
            Usuario user = new Usuario();
            AccesoDB datos = new AccesoDB();
            user.id = -1;


            try
            {
                datos.setearQuerySP("sp_GetUsuarioPorID");
                datos.setearParametro("@usuario_ID", id);
                datos.ejectuarLectura();
                if(datos.Lector.Read())
                {
                    user.id = (int)datos.Lector["id"];
                    user.email = datos.Lector["email"].ToString();
                    user.password_hash = datos.Lector["password_hash"].ToString();
                    user.img_url = datos.Lector["img_url"] != DBNull.Value ? datos.Lector["img_url"].ToString() : "";
                    user.rol_type = (UserRole)datos.Lector["id_rol"];
                    user.fecha_creacion = (DateTime)datos.Lector["fecha_creacion"];
                    user.activo = (bool)datos.Lector["activo"];
                    return user;
                }
                return user;
            } catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                return user;
            }
            finally
            {
                datos.cerrarConexion();
            }
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
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<ListItem> ListarRoles()
        {
            AccesoDB datos = new AccesoDB();
            List<ListItem> roles = new List<ListItem>();

            try
            {
                datos.setearQuery("SELECT * FROM ROLES");
                datos.ejectuarLectura();

                while(datos.Lector.Read())
                {
                    roles.Add(new ListItem
                    {
                        Text = datos.Lector["rol_name"].ToString(),
                        Value = datos.Lector["id"].ToString()
                    });
                }
                roles.Insert(0, new ListItem("-- Seleccione un rol --", "0"));
                return roles;

            }catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                return roles;
            }finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

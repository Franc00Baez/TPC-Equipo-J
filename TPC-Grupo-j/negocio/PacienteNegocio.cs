using dominio;
using helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearQuery("SELECT id, nombre, apellido, email, telefono, nacimiento, dni, activo FROM PACIENTES");
                accesoDB.ejectuarLectura();

                while (accesoDB.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.id = accesoDB.Lector.GetInt32(0);
                    aux.nombre = accesoDB.Lector.GetString(1);
                    aux.apellido = accesoDB.Lector.GetString(2);
                    aux.email = accesoDB.Lector.GetString(3);
                    aux.telefono = accesoDB.Lector.GetString(4);
                    aux.nacimiento = accesoDB.Lector.GetDateTime(5);
                    aux.dni = accesoDB.Lector.GetString(6);
                    aux.activo = accesoDB.Lector.GetBoolean(7);

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
        
        public void insertarNuevo(Paciente nuevo)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuery("INSERT INTO PACIENTES (nombre, apellido, email, telefono, nacimiento, dni, activo) values (@nombre, @apellido, @email, @telefono, @nacimiento, @dni, 1);");
                accesoDB.setearParametro("@nombre", nuevo.nombre);
                accesoDB.setearParametro("@apellido", nuevo.apellido);
                accesoDB.setearParametro("@email", nuevo.email);
                accesoDB.setearParametro("@telefono", nuevo.telefono);
                accesoDB.setearParametro("@nacimiento", nuevo.nacimiento);
                accesoDB.setearParametro("@dni", nuevo.dni);
                accesoDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }

        /*
        public void actualizar(Usuario usuario)
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
                if (datos.Lector.Read())
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
            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                return user;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        */
    }
}

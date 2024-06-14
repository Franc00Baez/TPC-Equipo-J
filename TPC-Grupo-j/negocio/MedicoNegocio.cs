using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class MedNegocio
    {
        public List<Medico> listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearQuery("SELECT id, usuario_id, nombre, apellido, nacimiento FROM DOCTORES");
                accesoDB.ejectuarLectura();

                while (accesoDB.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.id = accesoDB.Lector.GetInt32(0);
                    aux.usuario_id = accesoDB.Lector.GetInt32(1);
                    aux.nombre = accesoDB.Lector.GetString(2);
                    aux.apellido = accesoDB.Lector.GetString(3);
                    aux.nacimiento = accesoDB.Lector.GetDateTime(4);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                throw ex;
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }

        public void insertarNuevo(Medico nuevo)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuery("INSERT INTO DOCTORES (nombre, apellido, nacimiento) values (@nombre, @apellido, @nacimiento);");
                accesoDB.setearParametro("@nombre", nuevo.nombre);
                accesoDB.setearParametro("@apellido", nuevo.apellido);
                accesoDB.setearParametro("@nacimiento", nuevo.nacimiento);
                accesoDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                throw ex;

            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }


        public void actualizar(Medico actualizado)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuery("UPDATE DOCTORES SET nombre = @nombre, apellido = @apellido,nacimiento = @nacimiento WHERE id = @id;");
                accesoDB.setearParametro("@nombre", actualizado.nombre);
                accesoDB.setearParametro("@apellido", actualizado.apellido);
                accesoDB.setearParametro("@nacimiento", actualizado.nacimiento);
                accesoDB.setearParametro("@id", actualizado.id);

                accesoDB.ejecutarAccion();
            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                throw ex;
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }
    }
}


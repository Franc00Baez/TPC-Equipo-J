using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearQuery("SELECT id, paciente_id, doctor_id, fecha, hora, estado_id, observacion FROM TURNOS");
                accesoDB.ejectuarLectura();

                while (accesoDB.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.id = accesoDB.Lector.GetInt32(0);
                    aux.paciente_id = accesoDB.Lector.GetInt32(1);
                    aux.doctor_id = accesoDB.Lector.GetInt32(2);
                    aux.fecha = accesoDB.Lector.GetDateTime(3);
                    aux.hora = accesoDB.Lector.GetTimeSpan(4);
                    aux.estado_id = accesoDB.Lector.GetInt32(5);
                    aux.observaciones = accesoDB.Lector.GetString(6);

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

        public void insertarNuevo(Turno nuevo)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuery("INSERT INTO PACIENTES (id, paciente_id, doctor_id, fecha, hora, estado_id, observacion) values (@id, @paciente_id, @doctor_id, @fecha, @hora, 1, @observacion);");
                accesoDB.setearParametro("@id", nuevo.id);
                accesoDB.setearParametro("@paciente_id", nuevo.paciente_id);
                accesoDB.setearParametro("@doctor_id", nuevo.doctor_id);
                accesoDB.setearParametro("@fecha", nuevo.fecha);
                accesoDB.setearParametro("@hora", nuevo.hora);
                accesoDB.setearParametro("@estado_id", nuevo.estado_id);
                accesoDB.setearParametro("@observaciones", nuevo.observaciones);
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
        public void actualizar(Turno turno)
        {
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                accesoDB.setearQuery("UPDATE PACIENTES SET nombre = @nombre, apellido = @apellido, email = @email, telefono = @telefono, nacimiento = @nacimiento, dni = @dni, activo = @activo WHERE id = @id;");
                accesoDB.setearParametro("@nombre", turno.nombre);
                accesoDB.setearParametro("@apellido", turno.apellido);
                accesoDB.setearParametro("@email", turno.email);
                accesoDB.setearParametro("@telefono", turno.telefono);
                accesoDB.setearParametro("@nacimiento", turno.nacimiento);
                accesoDB.setearParametro("@dni", turno.dni);
                accesoDB.setearParametro("@activo", turno.activo);
                accesoDB.setearParametro("@id", turno.id);

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
        */
    }
}

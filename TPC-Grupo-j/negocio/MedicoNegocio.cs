using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class MedicoNegocio
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

        public int insertarNuevo(Medico nuevo)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuerySP("sp_InsertarMedico");
                datos.setearParametro("@UsuarioID", nuevo.id);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Apellido", nuevo.apellido);
                datos.setearParametro("@Nacimiento", nuevo.nacimiento != null ? nuevo.nacimiento : DateTime.MaxValue);
                datos.setearParametroSalida("@MedicoID", System.Data.SqlDbType.Int);

                datos.ejecutarAccion();

                return (int)datos.obtenerParametroSalida("@MedicoID");
            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
                return -1;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void InsertarEspecialidades(Medico nuevo, int id)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                foreach (Especialidad especialidad in nuevo.especialidades)
                {
                    System.Diagnostics.Debug.WriteLine(especialidad.id + ": " + especialidad.nombre);
                    datos.setearQuery("INSERT INTO ESPECIALIDADES_X_DOCTORES (doctor_id, especialidad_id) VALUES (@MedicoID, @EspecialidadID)");
                    datos.setearParametro("@MedicoID", id);
                    datos.setearParametro("@EspecialidadID", especialidad.id);
                    datos.ejecutarAccion();
                }

            }catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void InsertarTurnos(Medico nuevo, int id)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                foreach (Horario horario in nuevo.Turnos.Values)
                {
                    System.Diagnostics.Debug.WriteLine(horario.ToString());
                    datos.setearQuery("INSERT INTO TURNOS_DE_TRABAJO (doctor_id, dia, hora_inicio, hora_final) VALUES (@MedicoID, @Dia, @HoraInicio, @HoraFinal)");
                    datos.setearParametro("@MedicoID", id);
                    datos.setearParametro("@Dia", horario.Dia);
                    datos.setearParametro("@HoraInicio", horario.HoraInicio);
                    datos.setearParametro("@HoraFinal", horario.HoraFinal);
                    datos.ejecutarAccion();
                }

            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }finally
            {
                datos.cerrarConexion();
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


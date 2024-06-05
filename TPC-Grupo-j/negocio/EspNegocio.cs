using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EspNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDB accesoDB = new AccesoDB();

            try
            {
                accesoDB.setearQuery("select id, especialidad_name FROM ESPECIALIDADES");
                accesoDB.ejectuarLectura();

                while (accesoDB.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.id = accesoDB.Lector.GetInt32(0);
                    aux.nombre = accesoDB.Lector.GetString(1);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Hay un error en la DB" + ex.Message);
            }
            finally
            {
                accesoDB.cerrarConexion();
            }
        }
    }
}

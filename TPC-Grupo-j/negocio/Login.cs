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
        private AccesoDB datos = new AccesoDB();
        private Usuario usuario = new Usuario();
        private HashService service = new HashService();

        public int ValidarUsuario(string email, string password_hash)
        {
            datos.setearQuerySP("sp_ValidarUsuario");
            datos.setearParametro("@email", email);
            datos.setearParametro("@password_hash", password_hash);
            datos.ejectuarLectura();

            if(datos.Lector.Read())
            {
                int id = (int)datos.Lector["id"];
                return id;
            }

            return -1;
        }
    }
}

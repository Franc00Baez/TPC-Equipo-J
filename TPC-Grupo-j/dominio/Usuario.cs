using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using helpers;

namespace dominio
{
    public class Usuario
    {
        public Usuario()
        {
            this.id = 0;
        }
        public Usuario(int rol)
        {
            this.rol_type = (UserRole)rol;
        }
        public int id { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string img_url { get; set; }
        public DateTime fecha_creacion { get; set; }

        public UserRole rol_type { get; set; }
    }
}

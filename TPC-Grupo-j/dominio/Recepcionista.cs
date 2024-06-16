using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Recepcionista : Usuario
    {
        public Recepcionista(Usuario user )
        {
            this.id = user.id;
            this.email = user.email;
            this.password_hash = user.password_hash;
            this.img_url = user.img_url;
            this.fecha_creacion = user.fecha_creacion;
            this.rol_type = user.rol_type;
            this.activo = user.activo;
        }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }

    }
}

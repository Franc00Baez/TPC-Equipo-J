using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico : Usuario
    {
        public Medico()
        {
            this.especialidades = new List<Especialidad>();
            this.Turnos= new Dictionary<string, Horario>();
        }
        public Medico(Usuario user)
        {
            this.id = user.id;
            this.email = user.email;
            this.password_hash = user.password_hash;
            this.img_url = user.img_url;
            this.fecha_creacion = user.fecha_creacion;
            this.rol_type = user.rol_type;
            this.activo = user.activo;
            this.especialidades = new List<Especialidad>();
            this.Turnos = new Dictionary<string, Horario>();
        }
        public int id_medico { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public List<Especialidad> especialidades { get; set; }
        public Dictionary<string, Horario> Turnos { get; set; }

    }
}

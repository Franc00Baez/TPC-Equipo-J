using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico
    {
        public string nombre { get; set;  }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public List<Especialidad> especialidades { get; set; }
    }
}

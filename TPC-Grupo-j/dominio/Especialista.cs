using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Especialista : Usuario
    {
        public int idMed { get; set; }

        public int idUsuario { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public DateTime fechaNac { get; set; }
    }
}

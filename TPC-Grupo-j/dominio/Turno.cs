using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public int id { get; set; }

        public int paciente_id { get; set; }

        public int doctor_id { get; set; }

        public DateTime fecha { get; set; }

        public TimeSpan hora { get; set; }

        public int estado_id { get; set; }

        public string observaciones { get; set; }
    }
}

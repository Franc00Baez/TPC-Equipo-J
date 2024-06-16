using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Horario
    {
        public string Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }

        public override string ToString()
        {
            return Dia + ": " + HoraInicio.ToString() + " // " + HoraFinal.ToString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Doutores
    {
        public int IdDoutor { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string CrmUf { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Pacientes IdPacienteNavigation { get; set; }
    }
}

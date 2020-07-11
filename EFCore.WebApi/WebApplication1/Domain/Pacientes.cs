using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Doutores = new HashSet<Doutores>();
        }

        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public DateTime BirdDate { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Doutores> Doutores { get; set; }
    }
}

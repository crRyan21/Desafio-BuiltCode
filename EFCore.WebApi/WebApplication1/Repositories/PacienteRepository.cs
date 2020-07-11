using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public class PacienteRepository
    {
        public List<Pacientes> Listar()
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                return ctx.Pacientes.ToList();
            }
        }
        public void Cadastrar(Pacientes paciente)
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                ctx.Pacientes.Add(paciente);
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                ctx.Pacientes.Remove(ctx.Pacientes.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Pacientes paciente, int id)
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                Pacientes pacienteBuscado = ctx.Pacientes.FirstOrDefault(x => x.IdPaciente == paciente.IdPaciente);

                pacienteBuscado.IdPaciente = id;
                pacienteBuscado.Nome = paciente.Nome;
                pacienteBuscado.BirdDate = paciente.BirdDate;
                pacienteBuscado.Cpf = paciente.Cpf;


                ctx.Pacientes.Update(pacienteBuscado);
                ctx.SaveChanges();
            }
        }
        public Pacientes BuscarPorId(int id)
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                return ctx.Pacientes.Find(id);
            }
        }
    }
}

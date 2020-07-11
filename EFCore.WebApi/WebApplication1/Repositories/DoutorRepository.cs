using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public class DoutorRepository
    {

        Doutores doutor = new Doutores();
        public List<Doutores> Listar()
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                return ctx.Doutores.Include(x => x.IdPacienteNavigation).ToList();
            }
        }
        public void Cadastrar(Doutores doutor)
        {
            using(HospitalContext ctx = new HospitalContext())
            {
                ctx.Doutores.Add(doutor);
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                if (this.doutor.IdPaciente.Equals(null) )
                {
                ctx.Doutores.Remove(ctx.Doutores.Find(id));
                }
                ctx.SaveChanges();

            }
        }
            public void Atualizar(Doutores doutor, int id)
            {
                using (HospitalContext ctx = new HospitalContext())
                {
                    Doutores doutorBuscado = ctx.Doutores.FirstOrDefault(x => x.IdDoutor == doutor.IdDoutor);

                doutorBuscado.IdDoutor = id;
                doutorBuscado.Nome = doutor.Nome;
                doutorBuscado.Crm = doutor.Crm;
                doutorBuscado.CrmUf = doutor.CrmUf;
                doutorBuscado.IdPaciente = doutor.IdPaciente;


                    ctx.Doutores.Update(doutorBuscado);
                    ctx.SaveChanges();
                }
            }
        public Doutores BuscarPorId(int id)
        {
            using (HospitalContext ctx = new HospitalContext())
            {
                return ctx.Doutores.Find(id);
            }
        }
    }
}

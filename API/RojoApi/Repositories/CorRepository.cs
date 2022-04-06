using Microsoft.EntityFrameworkCore;
using RojoAPI.Contexts;
using RojoAPI.Domains;
using RojoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Repositories
{
    public class CorRepository : ICorRepository
    {
        RojoContext ctx = new RojoContext();
        public void Atualizar(int id, Cor CorAtualizada)
        {
            Cor CorBuscada = ctx.Cors.Find(id);

            if (CorAtualizada.NomeCor != null)
            {
                CorBuscada.NomeCor = CorAtualizada.NomeCor;

                ctx.Cors.Update(CorBuscada);

                ctx.SaveChanges();
            }
        }

        public Cor BuscarPorId(int id)
        {
            return ctx.Cors.FirstOrDefault(x => x.Idcor == id);
        }

        public void Cadastrar(Cor NovaCor)
        {
            ctx.Cors.Add(NovaCor);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Cors.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Cor> Listar()
        {
            return ctx.Cors
           .Select(x => new Cor
           {
               Idcor = x.Idcor,
               NomeCor = x.NomeCor,
           })
           .ToList();
        }
    }
}

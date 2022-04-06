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
    public class ComentarioRepository : IComentarioRepository
    {
        RojoContext ctx = new RojoContext();
        public void Atualizar(int id, Comentario ComentarioAtualizado)
        {
            Comentario ComentarioBuscada = ctx.Comentarios.Find(id);

            if (ComentarioAtualizado.CadastrarComentario != null)
            {
                ComentarioBuscada.CadastrarComentario = ComentarioAtualizado.CadastrarComentario;

                ctx.Comentarios.Update(ComentarioBuscada);

                ctx.SaveChanges();
            }
        }

        public Comentario BuscarPorId(int id)
        {
            return ctx.Comentarios.FirstOrDefault(x => x.Idcomentario == id);
        }

        public void Cadastrar(Comentario NovoComentario)
        {
            ctx.Comentarios.Add(NovoComentario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Comentarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Comentario> Listar()
        {
        return ctx.Comentarios
        .Include(x => x.IdeventoNavigation)
        .Select(x => new Comentario
        {
            Idcomentario = x.Idcomentario,
            IdeventoNavigation =x.IdeventoNavigation,
            Idevento = x.Idevento,
            CadastrarComentario = x.CadastrarComentario,
        })
        .ToList();
        }
    }
}

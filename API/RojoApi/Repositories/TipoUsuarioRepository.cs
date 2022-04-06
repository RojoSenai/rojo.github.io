using RojoAPI.Contexts;
using RojoAPI.Domains;
using RojoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        RojoContext ctx = new RojoContext();

        public void Atualizar(int id, TipoUsuario UsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(x => x.IdtipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios
           .Select(x => new TipoUsuario
           {
               IdtipoUsuario = x.IdtipoUsuario,
               PerfisDeUsuario = x.PerfisDeUsuario,
           })
           .ToList();
        }
 
    }
}

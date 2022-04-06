using Microsoft.EntityFrameworkCore;
using ProjetoClassificados.Utils;
using RojoAPI.Contexts;
using RojoAPI.Domains;
using RojoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RojoContext ctx = new RojoContext();

        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Idusuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            string senhaHash = Criptografia.gerarHash(novoUsuario.Senha);
            novoUsuario.Senha = senhaHash;
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios
           .Include(x => x.IdempresaNavigation)
           .Select(x => new Usuario
           {
               Idusuario = x.Idusuario,
               IdempresaNavigation = x.IdempresaNavigation,
               IdtipoUsuario = x.IdtipoUsuario,
               Email = x.Email,
               Senha = x.Senha,
               NomeUsu = x.NomeUsu,
               ImagemUsuario = x.ImagemUsuario
           })
           .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha == senha)
                {
                    string senhaHash = Criptografia.gerarHash(senha);
                    usuario.Senha = senhaHash;
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                    return usuario;
                }
                bool confere = Criptografia.compararSenha(senha, usuario.Senha);
                if (confere)
                {
                    return usuario;
                }
            }
            return null;
        }

    }
}

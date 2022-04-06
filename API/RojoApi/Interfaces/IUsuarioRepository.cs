using RojoAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        Usuario Login(string Email, string Senha);
        Usuario BuscarPorId(int id);
        void Atualizar(int id, Usuario UsuarioAtualizado);
        void Deletar(int id);
        List<Usuario> Listar();
    }
}

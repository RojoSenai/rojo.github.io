using RojoAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Interfaces
{
    interface IComentarioRepository
    {
        void Cadastrar(Comentario NovoComentario);
        Comentario BuscarPorId(int id);
        void Atualizar(int id, Comentario ComentarioAtualizado);
        void Deletar(int id);
        List<Comentario> Listar();
    }
}

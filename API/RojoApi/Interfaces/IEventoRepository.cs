using RojoAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Interfaces
{
    interface IEventoRepository
    {
        void Cadastrar(Evento NovoEvento);
        Evento BuscarPorId(int id);
        void Atualizar(int id, Evento EventoAtualizado);
        void Deletar(int id);
        List<Evento> Listar();
    }
}

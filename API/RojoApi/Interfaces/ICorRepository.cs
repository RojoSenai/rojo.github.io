using RojoAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Interfaces
{
    interface ICorRepository
    {
        void Cadastrar(Cor NovaCor);
        Cor BuscarPorId(int id);
        void Atualizar(int id, Cor CorAtualizada);
        void Deletar(int id);
        List<Cor> Listar();
    }
}

using RojoAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Interfaces
{
    interface IEmpresaRepository
    {
        void Cadastrar(Empresa NovaEmpresa);
        Empresa BuscarPorId(int id);
        void Atualizar(int id, Empresa EmpresaAtualizada);
        void Deletar(int id);
        List<Empresa> Listar();
    }
}

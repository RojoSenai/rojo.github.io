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
    public class EmpresaRepository : IEmpresaRepository
    {
        RojoContext ctx = new RojoContext();
        public void Atualizar(int id, Empresa EmpresaAtualizada)
        {
            Empresa EmpresaBuscada = ctx.Empresas.Find(id);

            if (EmpresaAtualizada.Cnpj != null)
            {
                EmpresaBuscada.Cnpj = EmpresaAtualizada.Cnpj;

                ctx.Empresas.Update(EmpresaBuscada);

                ctx.SaveChanges();
            }
        }

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresas.Select(x => new Empresa()
            {
                Idempresa = x.Idempresa,
                Cnpj = x.Cnpj,
                Email = x.Email,
                Senha = x.Senha,
                NomeFantasia = x.NomeFantasia,
                RazaoSocial = x.RazaoSocial,
                FundaçãoAniversario = x.FundaçãoAniversario,
                Endereço = x.Endereço,
                Telefone = x.Telefone,
                TotalFuncionarios = x.TotalFuncionarios

            }).FirstOrDefault(x => x.Idempresa == id);
        }

        public void Cadastrar(Empresa NovaEmpresa)
        {
            ctx.Empresas.Add(NovaEmpresa);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Empresas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresas
           .Select(x => new Empresa
           {
               Idempresa = x.Idempresa,
               Cnpj = x.Cnpj,
               Email = x.Email,
               Senha = x.Senha,
               NomeFantasia = x.NomeFantasia,
               RazaoSocial = x.RazaoSocial,
               FundaçãoAniversario = x.FundaçãoAniversario,
               Endereço = x.Endereço,
               Telefone = x.Telefone,
               TotalFuncionarios = x.TotalFuncionarios
           })
           .ToList();
        }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace RojoAPI.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Eventos = new HashSet<Evento>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idempresa { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime FundaçãoAniversario { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public int TotalFuncionarios { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

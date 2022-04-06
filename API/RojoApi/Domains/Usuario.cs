using System;
using System.Collections.Generic;

#nullable disable

namespace RojoAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Idusuario { get; set; }
        public int? IdtipoUsuario { get; set; }
        public int? Idempresa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeUsu { get; set; }
        public string ImagemUsuario { get; set; }

        public virtual Empresa IdempresaNavigation { get; set; }
        public virtual TipoUsuario IdtipoUsuarioNavigation { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}

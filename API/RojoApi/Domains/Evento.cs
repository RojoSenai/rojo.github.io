using System;
using System.Collections.Generic;

#nullable disable

namespace RojoAPI.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int Idevento { get; set; }
        public int? Idempresa { get; set; }
        public int? Idusuario { get; set; }
        public string NomeEvento { get; set; }
        public string Palestrante { get; set; }
        public DateTime DataEventoIncio { get; set; }
        public DateTime DataEventoFim { get; set; }

        public virtual Empresa IdempresaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}

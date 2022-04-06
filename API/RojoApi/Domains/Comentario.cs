using System;
using System.Collections.Generic;

#nullable disable

namespace RojoAPI.Domains
{
    public partial class Comentario
    {
        public int Idcomentario { get; set; }
        public int? Idevento { get; set; }
        public string CadastrarComentario { get; set; }

        public virtual Evento IdeventoNavigation { get; set; }
    }
}

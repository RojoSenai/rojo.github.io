using System;
using System.Collections.Generic;

#nullable disable

namespace RojoAPI.Domains
{
    public partial class EstilizacaoApp
    {
        public int? Idempresa { get; set; }
        public int? Idcor { get; set; }
        public int? IdlogoBaner { get; set; }

        public virtual Cor IdcorNavigation { get; set; }
        public virtual Empresa IdempresaNavigation { get; set; }
        public virtual LogoBaner IdlogoBanerNavigation { get; set; }
    }
}

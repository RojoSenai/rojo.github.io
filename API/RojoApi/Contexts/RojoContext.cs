using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RojoAPI.Domains;

#nullable disable

namespace RojoAPI.Contexts
{
    public partial class RojoContext : DbContext
    {
        public RojoContext()
        {
        }

        public RojoContext(DbContextOptions<RojoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Cor> Cors { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<EstilizacaoApp> EstilizacaoApps { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<LogoBaner> LogoBaners { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=db-rojo.c7jsdtpno5d7.us-east-1.rds.amazonaws.com; database=Rojo_App; user Id=rojoadmin; pwd=ESrQ5GLdVsYVBX6ivcEf;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.Idcomentario)
                    .HasName("PK__Comentar__46E6637E0AB45A7B");

                entity.ToTable("Comentario");

                entity.Property(e => e.Idcomentario).HasColumnName("IDComentario");

                entity.Property(e => e.CadastrarComentario)
                    .IsRequired()
                    .HasMaxLength(2300)
                    .IsUnicode(false);

                entity.Property(e => e.Idevento).HasColumnName("IDEvento");

                entity.HasOne(d => d.IdeventoNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.Idevento)
                    .HasConstraintName("FK__Comentari__IDEve__114A936A");
            });

            modelBuilder.Entity<Cor>(entity =>
            {
                entity.HasKey(e => e.Idcor)
                    .HasName("PK__Cor__91A98A6462B2A48B");

                entity.ToTable("Cor");

                entity.Property(e => e.Idcor).HasColumnName("IDCor");

                entity.Property(e => e.NomeCor)
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Idempresa)
                    .HasName("PK__Empresa__ED09F0D57BD5E354");

                entity.ToTable("Empresa");

                entity.HasIndex(e => e.TotalFuncionarios, "UQ__Empresa__1A80EAB1BA26235D")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__Empresa__448779F0671B9AB2")
                    .IsUnique();

                entity.HasIndex(e => e.Endereço, "UQ__Empresa__4DFC5FCEBDFF988E")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone, "UQ__Empresa__4EC504B66A4FF699")
                    .IsUnique();

                entity.HasIndex(e => e.FundaçãoAniversario, "UQ__Empresa__5D2F4AA1F00FBB79")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Empresa__A9D10534D58DD09E")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Empresa__AA57D6B41FBE9116")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia, "UQ__Empresa__F5389F31BD11FF8A")
                    .IsUnique();

                entity.Property(e => e.Idempresa).HasColumnName("IDEmpresa");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereço)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FundaçãoAniversario).HasColumnType("date");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstilizacaoApp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EstilizacaoApp");

                entity.Property(e => e.Idcor).HasColumnName("IDCor");

                entity.Property(e => e.Idempresa).HasColumnName("IDEmpresa");

                entity.Property(e => e.IdlogoBaner).HasColumnName("IDLogoBaner");

                entity.HasOne(d => d.IdcorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idcor)
                    .HasConstraintName("FK__Estilizac__IDCor__5441852A");

                entity.HasOne(d => d.IdempresaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idempresa)
                    .HasConstraintName("FK__Estilizac__IDEmp__534D60F1");

                entity.HasOne(d => d.IdlogoBanerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdlogoBaner)
                    .HasConstraintName("FK__Estilizac__IDLog__5535A963");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.Idevento)
                    .HasName("PK__Evento__E6305302A883A689");

                entity.ToTable("Evento");

                entity.HasIndex(e => e.DataEventoFim, "UQ__Evento__6B726C72EFE653F8")
                    .IsUnique();

                entity.HasIndex(e => e.DataEventoIncio, "UQ__Evento__CA62D497D3A06A1A")
                    .IsUnique();

                entity.Property(e => e.Idevento).HasColumnName("IDEvento");

                entity.Property(e => e.DataEventoFim).HasColumnType("datetime");

                entity.Property(e => e.DataEventoIncio).HasColumnType("datetime");

                entity.Property(e => e.Idempresa).HasColumnName("IDEmpresa");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Palestrante)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdempresaNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.Idempresa)
                    .HasConstraintName("FK__Evento__IDEmpres__0D7A0286");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__Evento__IDUsuari__0E6E26BF");
            });

            modelBuilder.Entity<LogoBaner>(entity =>
            {
                entity.HasKey(e => e.IdlogoBaner)
                    .HasName("PK__LogoBane__622CD3B35960464C");

                entity.ToTable("LogoBaner");

                entity.Property(e => e.IdlogoBaner).HasColumnName("IDLogoBaner");

                entity.Property(e => e.Banert)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdtipoUsuario)
                    .HasName("PK__tipoUsua__53289754A7830C29");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdtipoUsuario).HasColumnName("IDTipoUsuario");

                entity.Property(e => e.PerfisDeUsuario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__523111691921B0AE");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534519D3FEE")
                    .IsUnique();

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idempresa).HasColumnName("IDEmpresa");

                entity.Property(e => e.IdtipoUsuario).HasColumnName("IDTipoUsuario");

                entity.Property(e => e.ImagemUsuario)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdempresaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idempresa)
                    .HasConstraintName("FK__Usuario__IDEmpre__59FA5E80");

                entity.HasOne(d => d.IdtipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdtipoUsuario)
                    .HasConstraintName("FK__Usuario__IDTipoU__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

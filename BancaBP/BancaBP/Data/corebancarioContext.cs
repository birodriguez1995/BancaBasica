using System;
using BancaBP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BancaBP.Data
{
    public partial class corebancarioContext : DbContext
    {
        public corebancarioContext()
        {
        }

        public corebancarioContext(DbContextOptions<corebancarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PS3NHN6;Initial Catalog=core_bancario;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IntCliecodigo)
                    .IsClustered(false);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IntCliecodigo).HasColumnName("INT_CLIECODIGO");

                entity.Property(e => e.VchClieapellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CLIEAPELLIDO");

                entity.Property(e => e.VchCliecedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CLIECEDULA");

                entity.Property(e => e.VchCliedireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CLIEDIRECCION");

                entity.Property(e => e.VchClieemail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CLIEEMAIL");

                entity.Property(e => e.VchClienombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CLIENOMBRE");

                entity.Property(e => e.VchClietelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CLIETELEFONO");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IntCuencodigo)
                    .IsClustered(false);

                entity.ToTable("CUENTA");

                entity.HasIndex(e => e.IntCliecodigo, "RELATIONSHIP_1_FK");

                entity.Property(e => e.IntCuencodigo).HasColumnName("INT_CUENCODIGO");

                entity.Property(e => e.DecCuensaldo)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("DEC_CUENSALDO");

                entity.Property(e => e.DttCuenfechacreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("DTT_CUENFECHACREACION");

                entity.Property(e => e.IntCliecodigo).HasColumnName("INT_CLIECODIGO");

                entity.Property(e => e.VchCuennumero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CUENNUMERO");

                entity.Property(e => e.VchCuentipo)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VCH_CUENTIPO");

                entity.HasOne(d => d.IntCliecodigoNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IntCliecodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUENTA_RELATIONS_CLIENTE");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.IntMovicodigo)
                    .IsClustered(false);

                entity.ToTable("MOVIMIENTO");

                entity.HasIndex(e => e.IntCuencodigo, "RELATIONSHIP_2_FK");

                entity.Property(e => e.IntMovicodigo).HasColumnName("INT_MOVICODIGO");

                entity.Property(e => e.DecMovisaldofinal)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("DEC_MOVISALDOFINAL");

                entity.Property(e => e.DecMovivalor)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("DEC_MOVIVALOR");

                entity.Property(e => e.DttMovifecha)
                    .HasColumnType("datetime")
                    .HasColumnName("DTT_MOVIFECHA");

                entity.Property(e => e.IntCuencodigo).HasColumnName("INT_CUENCODIGO");

                entity.Property(e => e.VchMovicuentdest)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VCH_MOVICUENTDEST");

                entity.Property(e => e.VchMovicuentorig)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VCH_MOVICUENTORIG");

                entity.Property(e => e.VchMovitipo)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("VCH_MOVITIPO")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IntCuencodigoNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IntCuencodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOVIMIEN_RELATIONS_CUENTA");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IntUsucodigo)
                    .IsClustered(false);

                entity.ToTable("USUARIO");

                entity.Property(e => e.IntUsucodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("INT_USUCODIGO");

                entity.Property(e => e.VchRol)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_ROL");

                entity.Property(e => e.VchUsuapellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUAPELLIDO");

                entity.Property(e => e.VchUsucedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUCEDULA");

                entity.Property(e => e.VchUsudireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUDIRECCION");

                entity.Property(e => e.VchUsuemail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUEMAIL");

                entity.Property(e => e.VchUsunombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUNOMBRE");

                entity.Property(e => e.VchUsupassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUPASSWORD");

                entity.Property(e => e.VchUsutelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUTELEFONO");

                entity.Property(e => e.VchUsuusuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VCH_USUUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using SGChallengeApplication.Data.Models;

namespace SGChallengeApplication.Models;

public partial class ChallengeSgContext : DbContext
{
    public ChallengeSgContext()
    {
    }

    public ChallengeSgContext(DbContextOptions<ChallengeSgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuenta { get; set; }

    public virtual DbSet<Localidad> Localidads { get; set; }

    public virtual DbSet<MonedaPais> MonedaPais { get; set; }

    public virtual DbSet<Moneda> Moneda { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.ToTable("Banco");

            entity.HasIndex(e => e.Id, "UQ__Banco__3214EC067EDCD9F2").IsUnique();

            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.BancoUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banco_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.BancoUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banco_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Id, "UQ__Cliente__3214EC06C202E570").IsUnique();

            entity.Property(e => e.Apellido).IsUnicode(false);
            entity.Property(e => e.Calle).IsUnicode(false);
            entity.Property(e => e.Cuil)
                .IsUnicode(false)
                .HasColumnName("CUIL");
            entity.Property(e => e.Cuit)
                .IsUnicode(false)
                .HasColumnName("CUIT");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Mail).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.NroDocumento).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdLocalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_IdLocalidad");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_IdTipoDocumento");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ClienteIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_IdUsuario");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.ClienteUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.ClienteUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ__Cuenta__3214EC0664F3E67C").IsUnique();

            entity.Property(e => e.Alias).IsUnicode(false);
            entity.Property(e => e.Cbu)
                .IsUnicode(false)
                .HasColumnName("CBU");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Observacion).IsUnicode(false);
            entity.Property(e => e.Saldo).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_IdCliente");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_IdMoneda");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_IdSucursal");

            entity.HasOne(d => d.IdTipoCuentaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_IdTipoCuenta");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.CuentumUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.CuentumUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.ToTable("Localidad");

            entity.HasIndex(e => e.Id, "UQ__Localida__3214EC06EA88061D").IsUnique();

            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Localidads)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidad_IdProvincia");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.LocalidadUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidad_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.LocalidadUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidad_UsuarioUltimaModif");
        });

        modelBuilder.Entity<MonedaPais>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ__MonedaPa__3214EC0612336C05").IsUnique();

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.MonedaPais)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonedaPais_IdMoneda");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.MonedaPais)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonedaPais_IdPais");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.MonedaPaiUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonedaPais_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.MonedaPaiUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonedaPais_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ__Moneda__3214EC06A8D958E6").IsUnique();

            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.MonedumUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Moneda_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.MonedumUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Moneda_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ__Pais__3214EC06500262D5").IsUnique();

            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.PaiUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pais_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.PaiUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pais_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ__Provinci__3214EC064D613652").IsUnique();

            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_IdPais");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.ProvinciumUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.ProvinciumUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.HasIndex(e => e.Id, "UQ__Rol__3214EC06BB3F73E4").IsUnique();

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.RolUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.RolUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("Sucursal");

            entity.HasIndex(e => e.Id, "UQ__Sucursal__3214EC06E4A48319").IsUnique();

            entity.Property(e => e.Calle).IsUnicode(false);
            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdBanco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_IdBanco");

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdLocalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_IdLocalidad");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.SucursalUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.SucursalUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_UsuarioUltimaModif");
        });

        modelBuilder.Entity<TipoCuenta>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ__TipoCuen__3214EC06FFE464F5").IsUnique();

            entity.Property(e => e.Codigo).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.TipoCuentumUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoCuenta_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.TipoCuentumUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoCuenta_UsuarioUltimaModif");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.Id, "UQ__TipoDocu__3214EC06B3189852").IsUnique();

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.Observacion).IsUnicode(false);
            entity.Property(e => e.TipoDocumento1)
                .IsUnicode(false)
                .HasColumnName("TipoDocumento");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.TipoDocumentoUsuarioCreacionNavigations)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoDocumento_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.TipoDocumentoUsuarioUltimaModifNavigations)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoDocumento_UsuarioUltimaModif");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Id, "UQ__Usuario__3214EC0656B9F19D").IsUnique();

            entity.Property(e => e.Contrasenia).IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaModif).HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_IdRol");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.InverseUsuarioCreacionNavigation)
                .HasForeignKey(d => d.UsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_UsuarioCreacion");

            entity.HasOne(d => d.UsuarioUltimaModifNavigation).WithMany(p => p.InverseUsuarioUltimaModifNavigation)
                .HasForeignKey(d => d.UsuarioUltimaModif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_UsuarioUltimaModif");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

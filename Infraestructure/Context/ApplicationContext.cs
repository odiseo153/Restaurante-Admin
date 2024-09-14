using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Plato> Platos { get; set; }

    public virtual DbSet<Restaurants> Restaurantes { get; set; }

    public virtual DbSet<TiposPlato> TiposPlatos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3213E83F23AED05E");

            entity.ToTable("clientes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(11)
                .HasColumnName("numero_telefono");
            entity.Property(e => e.PuntosFidelidad)
                .HasDefaultValue(0)
                .HasColumnName("puntos_fidelidad");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pedidos__3213E83F5C831E62");

            entity.ToTable("pedidos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pedido");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto_total");
            entity.Property(e => e.RestauranteId).HasColumnName("restaurante_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_pedidos_cliente");

            entity.HasOne(d => d.Restaurante).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.RestauranteId)
                .HasConstraintName("FK_pedidos_restaurante");
        });

        modelBuilder.Entity<Plato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__platos__3213E83FC2D4BD52");

            entity.ToTable("platos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");

            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");

            entity.Property(e => e.Estado)
                .HasColumnType("bit")
                .HasColumnName("estado");

            entity.Property(e => e.Imagen)
               .HasColumnType("text")
               .HasColumnName("imagen");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.Property(e => e.RestauranteId).HasColumnName("restaurante_id");

            entity.Property(e => e.TipoId).HasColumnName("tipo_id");
            
            entity.HasOne(d => d.Restaurante).WithMany(p => p.Platos)
                .HasForeignKey(d => d.RestauranteId)
                .HasConstraintName("FK_platos_restaurante");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Plato)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK_platos_tipo");
        });

        modelBuilder.Entity<Restaurants>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__restaura__3213E83F5B8E3B43");

            entity.ToTable("restaurantes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");

            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");

            entity.Property(e => e.clave)
               .HasMaxLength(255)
               .HasColumnName("clave");

            entity.Property(e => e.Imagen)
                .HasColumnType("text")
                .HasColumnName("imagen");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(50)
                .HasColumnName("numero_telefono");
        });

        modelBuilder.Entity<TiposPlato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipos_pl__3213E83FD7099EA7");

            entity.ToTable("tipos_platos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Social>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__social_pl__2611E83FD7099EA7");

            entity.ToTable("social");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

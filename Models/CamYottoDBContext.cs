using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CamYottoAPI.Models
{
    public partial class CamYottoDBContext : DbContext
    {
        public CamYottoDBContext()
        {
        }

        public CamYottoDBContext(DbContextOptions<CamYottoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arné> Arnés { get; set; }
        public virtual DbSet<Cama> Camas { get; set; }
        public virtual DbSet<Chaleco> Chalecos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Maquinarium> Maquinaria { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<VwPedidoxProductoxCliente> VwPedidoxProductoxClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-FDRGAC6 ;DATABASE=CamYottoDB; User Id=CamYotto; Password=1316");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arné>(entity =>
            {
                entity.HasKey(e => e.Idarnes)
                    .HasName("PK__Arnés__4294CC923195639C");

                entity.Property(e => e.Idarnes)
                    .HasMaxLength(50)
                    .HasColumnName("IDArnes");

                entity.Property(e => e.Colores)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Talla)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cama>(entity =>
            {
                entity.HasKey(e => e.Idcama)
                    .HasName("PK__Cama__43A2DBC13EFDC972");

                entity.ToTable("Cama");

                entity.Property(e => e.Idcama)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCama");

                entity.Property(e => e.Colores)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DetallePers)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Medidas).HasMaxLength(50);
            });

            modelBuilder.Entity<Chaleco>(entity =>
            {
                entity.HasKey(e => e.Column)
                    .HasName("PK__Chaleco__A23042FB499C4A3A");

                entity.ToTable("Chaleco");

                entity.Property(e => e.Column).ValueGeneratedNever();

                entity.Property(e => e.Colores)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idchaleco).HasColumnName("IDChaleco");

                entity.Property(e => e.Medidas).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.Talla)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__Cliente__9B8553FCC250F377");

                entity.ToTable("Cliente");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioIdusuario).HasColumnName("UsuarioIDUsuario");

                entity.HasOne(d => d.UsuarioIdusuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UsuarioIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCliente648785");
            });

            modelBuilder.Entity<Maquinarium>(entity =>
            {
                entity.HasKey(e => e.Idmaquinaria)
                    .HasName("PK__Maquinar__6B87042F198904DF");

                entity.Property(e => e.Idmaquinaria).HasColumnName("IDMaquinaria");

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Funcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioIdusuario).HasColumnName("UsuarioIDUsuario");

                entity.HasOne(d => d.UsuarioIdusuarioNavigation)
                    .WithMany(p => p.Maquinaria)
                    .HasForeignKey(d => d.UsuarioIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMaquinaria513504");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.UsuarioIdusuario).HasColumnName("UsuarioIDUsuario");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FKPedido136721");

                entity.HasOne(d => d.UsuarioIdusuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.UsuarioIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPedido198801");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__Producto__ABDAF2B4A012AACC");

                entity.ToTable("Producto");

                entity.Property(e => e.Idproducto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDProducto");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdtipoProdcto).HasColumnName("IDTipoProdcto");

                entity.Property(e => e.UsuarioIdusuario).HasColumnName("UsuarioIDUsuario");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithOne(p => p.Producto)
                    .HasForeignKey<Producto>(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKProducto106405");

                entity.HasOne(d => d.Idproducto1)
                    .WithOne(p => p.Producto)
                    .HasForeignKey<Producto>(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKProducto23698");

                entity.HasOne(d => d.Idproducto2)
                    .WithOne(p => p.Producto)
                    .HasForeignKey<Producto>(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKProducto243051");

                entity.HasOne(d => d.UsuarioIdusuarioNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.UsuarioIdusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKProducto38637");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__5231116998B41A37");

                entity.ToTable("Usuario");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Contrasenna)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPedidoxProductoxCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwPedidoxProductoxCliente");

                entity.Property(e => e.DetalleProducto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Detalle Producto");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Direccion Cliente");

                entity.Property(e => e.Fecha).HasColumnType("smalldatetime");

                entity.Property(e => e.IdCliente).HasColumnName("ID Cliente");

                entity.Property(e => e.IdPedido).HasColumnName("ID Pedido");

                entity.Property(e => e.IdProducto).HasColumnName("ID Producto");

                entity.Property(e => e.IdUsuario).HasColumnName("ID Usuario");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Nombre Cliente");

                entity.Property(e => e.PrecioTotal).HasColumnName("Precio Total");

                entity.Property(e => e.TelefonoCliente).HasColumnName("Telefono Cliente");

                entity.Property(e => e.ValorProducto).HasColumnName("Valor Producto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

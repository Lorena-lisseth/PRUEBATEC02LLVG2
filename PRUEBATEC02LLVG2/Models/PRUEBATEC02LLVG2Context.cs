using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRUEBATEC02LLVG2.Models
{
    public partial class PRUEBATEC02LLVG2Context : DbContext
    {
        public PRUEBATEC02LLVG2Context()
        {
        }

        public PRUEBATEC02LLVG2Context(DbContextOptions<PRUEBATEC02LLVG2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Especy> Especies { get; set; } = null!;
        public virtual DbSet<Flore> Flores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especy>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Flore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoId).HasColumnName("tipo_id");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Flores)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK__Flores__tipo_id__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

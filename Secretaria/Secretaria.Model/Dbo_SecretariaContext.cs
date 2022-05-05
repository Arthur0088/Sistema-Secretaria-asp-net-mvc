﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Secretaria.Model
{
    public partial class Dbo_SecretariaContext : DbContext
    {
        public Dbo_SecretariaContext()
        {
        }

        public Dbo_SecretariaContext(DbContextOptions<Dbo_SecretariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAluno> TbAluno { get; set; }
        public virtual DbSet<TbCurso> TbCurso { get; set; }
        public virtual DbSet<TbMatricula> TbMatricula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GT5KKLK\\SQLEXPRESS;Initial Catalog=dbo_Secretaria;User ID=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__aluno__0C5BC84955BEB4AD");

                 entity.HasOne(d => d.CursoIdCursoNavigation)
                    .WithMany(p => p.TbAluno)
                    .HasForeignKey(d => d.CursoIdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aluno__curso_idC__38996AB5");
            });

            modelBuilder.Entity<TbCurso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED05951DE54B");
            });

            modelBuilder.Entity<TbMatricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__matricul__72013C990B7BF6C4");

                entity.HasOne(d => d.AlunoIdAlunoNavigation)
                    .WithMany(p => p.TbMatricula)
                    .HasForeignKey(d => d.AlunoIdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__aluno__3B75D760");

                entity.HasOne(d => d.CursoIdCursoNavigation)
                    .WithMany(p => p.TbMatricula)
                    .HasForeignKey(d => d.CursoIdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__matricula__curso__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wapi_the_Infra.Models
{
    [ExcludeFromCodeCoverage]
    public partial class modelContext : DbContext
    {
        public modelContext()
        {
        }

        public modelContext(DbContextOptions<modelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Hero> Hero { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdClassroom).HasColumnName("id_Classroom");

                entity.Property(e => e.IdHeroEleve).HasColumnName("id_Hero_Eleve");

                entity.Property(e => e.IdHeroProfPrincipal).HasColumnName("id_Hero_Prof_Principal");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClassroomNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.IdClassroom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__id_Classr__5629CD9C");

                entity.HasOne(d => d.IdHeroProfPrincipalNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.IdHeroProfPrincipal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__id_Hero_P__5535A963");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdSchool).HasColumnName("id_school");

                entity.Property(e => e.NomClass)
                    .IsRequired()
                    .HasColumnName("Nom_Class")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSchoolNavigation)
                    .WithMany(p => p.Classroom)
                    .HasForeignKey(d => d.IdSchool)
                    .HasConstraintName("FK__Classroom__id_sc__59063A47");
            });

            modelBuilder.Entity<Hero>(entity =>
            {
                entity.ToTable("hero");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HeroAlter)
                    .HasColumnName("heroAlter")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NomEcole)
                    .IsRequired()
                    .HasColumnName("Nom_Ecole")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

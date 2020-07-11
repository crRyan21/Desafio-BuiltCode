using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doutores> Doutores { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Password=sa132;Persist Security Info=True;User ID=sa;Initial Catalog=Hospital;Data Source=LAB08DESK115429\\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Doutores>(entity =>
            {
                entity.HasKey(e => e.IdDoutor)
                    .HasName("PK__Doutores__38333C8D28BABAF9");

                entity.HasIndex(e => e.Crm)
                    .HasName("UQ__Doutores__C1FF83F7166A3F4D")
                    .IsUnique();

                entity.HasIndex(e => e.CrmUf)
                    .HasName("UQ__Doutores__FB421C12727CB183")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CrmUf)
                    .IsRequired()
                    .HasColumnName("CrmUF")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Doutores)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Doutores__IdPaci__3C69FB99");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49B46991197");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Paciente__C1F897312E901A53")
                    .IsUnique();

                entity.Property(e => e.BirdDate).HasColumnType("date");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RepoPractice.Models
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

        public virtual DbSet<Assistant> Assistants { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<DrugsDetail> DrugsDetails { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-18JEBP4\\SQLEXPRESS;Database=Hospital;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assistant>(entity =>
            {
                entity.HasKey(e => e.AssistantsId)
                    .HasName("PK__Assistan__26A79C57A7EA8A42");

                entity.Property(e => e.AssistantsId)
                    .ValueGeneratedNever()
                    .HasColumnName("assistantsId");

                entity.Property(e => e.AssistantName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("assistantName");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Assistants)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Assistant__depar__3B75D760");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("departmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departmentName");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorsId)
                    .HasName("PK__Doctors__B3FA06DE3BCC849A");

                entity.Property(e => e.DoctorsId)
                    .ValueGeneratedNever()
                    .HasColumnName("doctorsId");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("doctorName");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_deptId");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.Property(e => e.DrugId)
                    .ValueGeneratedNever()
                    .HasColumnName("drugId");

                entity.Property(e => e.DrugName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("drugName");
            });

            modelBuilder.Entity<DrugsDetail>(entity =>
            {
                entity.HasKey(e => e.DrugsDetailsId)
                    .HasName("PK__DrugsDet__598407A16C50B408");

                entity.Property(e => e.DrugsDetailsId)
                    .ValueGeneratedNever()
                    .HasColumnName("drugsDetailsId");

                entity.Property(e => e.DrugId).HasColumnName("drugId");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Timing)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("timing");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.DrugsDetails)
                    .HasForeignKey(d => d.DrugId)
                    .HasConstraintName("FK_DrugId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DrugsDetails)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("patientId");

                entity.Property(e => e.AssistantId).HasColumnName("assistantId");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("patientName");

                entity.HasOne(d => d.Assistant)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AssistantId)
                    .HasConstraintName("FK_AssistantId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_docId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

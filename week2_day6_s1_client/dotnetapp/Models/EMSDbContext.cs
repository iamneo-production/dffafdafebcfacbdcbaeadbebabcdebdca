using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnetapp.Models
{
    public partial class EMSDbContext : DbContext
    {
        public EMSDbContext()
        {
        }

        public EMSDbContext(DbContextOptions<EMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=EMSDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("Dept");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "UQ__Employee__AB6E6164180CE723")
                    .IsUnique();

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK__Employee__deptid__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

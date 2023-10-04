using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models;

public partial class FootballdbContext : DbContext
{
    public FootballdbContext()
    {
    }

    public FootballdbContext(DbContextOptions<FootballdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3DGC0GB\\SQLEXPRESS;Initial Catalog=footballdb;Integrated Security=True;Connect Timeout=300;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__players__3213E83F9F9D2EBD");

            entity.ToTable("players");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();;
            entity.Property(e => e.Appearances).HasColumnName("appearances");
            entity.Property(e => e.Goals).HasColumnName("goals");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Shirtno).HasColumnName("shirtno");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83F9863F2D3");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();;
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

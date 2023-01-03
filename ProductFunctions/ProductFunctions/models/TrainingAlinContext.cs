using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductFunctions
{
  public partial class TrainingAlinContext : DbContext
  {
    public TrainingAlinContext()
    {
    }

    public TrainingAlinContext(DbContextOptions<TrainingAlinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL\\SQL2012;Database=training_alin;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>(entity =>
      {
        entity.Property(e => e.Id)
              .ValueGeneratedNever()
              .HasColumnName("id");
        entity.Property(e => e.Description)
              .IsRequired()
              .HasMaxLength(200)
              .IsUnicode(false)
              .HasColumnName("description");
        entity.Property(e => e.Image)
              .IsRequired()
              .HasMaxLength(200)
              .IsUnicode(false)
              .HasColumnName("image");
        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(50)
              .IsUnicode(false)
              .HasColumnName("name");
        entity.Property(e => e.Price).HasColumnName("price");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}

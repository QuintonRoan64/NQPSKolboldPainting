using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

public partial class KoboldPaintingDbContext : DbContext
{
    public KoboldPaintingDbContext()
    {
    }

    public KoboldPaintingDbContext(DbContextOptions<KoboldPaintingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<KolboldUser> KolboldUsers { get; set; }

    public virtual DbSet<OwnedPaint> OwnedPaints { get; set; }

    public virtual DbSet<Paint> Paints { get; set; }

    public virtual DbSet<PaintRecipe> PaintRecipes { get; set; }

    public virtual DbSet<PaintType> PaintTypes { get; set; }

    public virtual DbSet<PaintsForRecipe> PaintsForRecipes { get; set; }

    public virtual DbSet<RefillPaint> RefillPaints { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<WantedPaint> WantedPaints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC27FBECD5AB");
        });

        modelBuilder.Entity<KolboldUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KolboldU__3214EC0775CE6BD8");
        });

        modelBuilder.Entity<OwnedPaint>(entity =>
        {
            entity.HasOne(d => d.KolboldUser).WithMany().HasConstraintName("OwnedPaint_FK_KolboldUserID");

            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("OwnedPaint_FK_PaintID");
        });

        modelBuilder.Entity<Paint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paints__3214EC27E38927AA");

            entity.HasOne(d => d.Company).WithMany(p => p.Paints).HasConstraintName("Paints_FK_CompanyID");

            entity.HasOne(d => d.PaintType).WithMany(p => p.Paints).HasConstraintName("Paints_FK_PaintTypeID");
        });

        modelBuilder.Entity<PaintRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaintRec__3214EC27A59E5CD4");

            entity.HasOne(d => d.KolboldUser).WithMany(p => p.PaintRecipes).HasConstraintName("PaintRecipes_FK_KolboldUserID");
        });

        modelBuilder.Entity<PaintType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaintTyp__3214EC27F1D59609");
        });

        modelBuilder.Entity<PaintsForRecipe>(entity =>
        {
            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("PaintsForRecipe_FK_PaintID");

            entity.HasOne(d => d.Recipe).WithMany().HasConstraintName("PaintsForRecipe_FK_RecipeID");
        });

        modelBuilder.Entity<RefillPaint>(entity =>
        {
            entity.HasOne(d => d.KolboldUser).WithMany().HasConstraintName("RefillPaint_FK_KolboldUserID");

            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("RefillPaint_FK_PaintID");
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasOne(d => d.KolboldUser).WithMany().HasConstraintName("Tutorials_FK_KolboldUserID");
        });

        modelBuilder.Entity<WantedPaint>(entity =>
        {
            entity.HasOne(d => d.KolboldUser).WithMany().HasConstraintName("WantedPaint_FK_KolboldUserID");

            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("WantedPaint_FK_PaintID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

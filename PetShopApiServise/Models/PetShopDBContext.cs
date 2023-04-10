﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;

namespace PetShopApiServise.Models;

public partial class PetShopDBContext : DbContext
{
    public PetShopDBContext(DbContextOptions<PetShopDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animals> Animals { get; set; }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<Comments> Comments { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animals>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A7307C30FBD77");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Animals)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Animals__Categor__286302EC");
        });

        modelBuilder.Entity<Categories>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0B5BCF82C3");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Comments>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFCAF12CFE76");

            entity.Property(e => e.Comment).IsRequired();

            entity.HasOne(d => d.Animal).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__Comments__Animal__2B3F6F97");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C60B91B06");

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
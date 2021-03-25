using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CaseManagementApi.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaseStatus> CaseStatus { get; set; }
        public virtual DbSet<CaseWorkers> CaseWorkers { get; set; }
        public virtual DbSet<Cases> Cases { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();///ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CaseWorkers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();///.ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cases>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();///ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CaseStatus)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseStatusId)
                    .HasConstraintName("FK_CaseStatus");

                entity.HasOne(d => d.CaseWorker)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseWorkerId)
                    .HasConstraintName("FK_CaseWorkers");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customers");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();///.ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CaseId)
                    .HasConstraintName("FK_Case");

                entity.HasOne(d => d.CaseWorker)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CaseWorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaseWorker");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();///.ValueGeneratedNever();

                entity.Property(e => e.AddressLine)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

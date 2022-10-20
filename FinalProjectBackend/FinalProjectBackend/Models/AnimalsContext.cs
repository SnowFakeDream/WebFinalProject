using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FinalProjectBackend.Models
{
    public partial class AnimalsContext : DbContext
    {
        public AnimalsContext()
        {
        }

        public AnimalsContext(DbContextOptions<AnimalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimalsTable> AnimalsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-0ORUV28R\\SQLEXPRESSCUSTOM;Initial Catalog=Animals;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalsTable>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.ToTable("Animals_Table");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("animalID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnimalCount).HasColumnName("animalCount");

                entity.Property(e => e.AnimalDescription).HasColumnName("animalDescription");

                entity.Property(e => e.AnimalImage).HasColumnName("animalImage");

                entity.Property(e => e.AnimalName)
                    .IsRequired()
                    .HasColumnName("animalName")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using DeathValley.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeathValley
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Chartsdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("Point");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.HasOne(d => d.Chart)
                    .WithMany(p => p.Points)
                    .HasForeignKey(x => x.ChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Point__ChartId__25869641");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(x => x.UserDataId)
                    .HasName("PK__UserData__6EE7A06FD37C994A");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.A).HasColumnName("a");

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.C).HasColumnName("c");

                entity.Property(e => e.Step).HasColumnName("step");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

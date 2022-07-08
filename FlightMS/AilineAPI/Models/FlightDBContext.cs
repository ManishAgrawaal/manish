using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AilineAPI.Models
{
    public partial class FlightDBContext : DbContext
    {
        public FlightDBContext()
        {
        }

        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InventoryTable> InventoryTables { get; set; }
        public virtual DbSet<RegisterTable> RegisterTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET338;Initial Catalog=FlightDB;User Id=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<InventoryTable>(entity =>
            {
                entity.ToTable("InventoryTable");

                entity.Property(e => e.EndDateTime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Instrument)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Meal)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nrows).HasColumnName("NRows");

                entity.Property(e => e.ScheduleDays)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateTime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TicketCost)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterTable>(entity =>
            {
                entity.ToTable("RegisterTable");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Caddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAddress");

                entity.Property(e => e.Cnumber).HasColumnName("CNumber");

                entity.Property(e => e.Logo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using DiggerScoreClient.MainModels;
using DiggerScoreClient.SubModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiggerScoreClient.Contexts
{
    public partial class DiggerScoreDbContext : DbContext
    {
        public DiggerScoreDbContext()
        {
        }

        public DiggerScoreDbContext(DbContextOptions<DiggerScoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coil> Coils { get; set; } = null!;
        public virtual DbSet<MetalDetector> MetalDetectors { get; set; } = null!;
        public virtual DbSet<OrderActionHistory> OrderActionHistories { get; set; } = null!;
        public virtual DbSet<OtherProduct> OtherProducts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserActionHistory> UserActionHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DiggerScoreDb;Username=postgres;Password=asdfgh");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
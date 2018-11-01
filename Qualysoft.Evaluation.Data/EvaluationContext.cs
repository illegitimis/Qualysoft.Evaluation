namespace Qualysoft.Evaluation.Data
{
    using Microsoft.EntityFrameworkCore;
    using Qualysoft.Evaluation.Domain;
    using System;

    /// <summary>
    /// Custom <see cref="DbContext"/> implementation
    /// </summary>
    public class EvaluationContext : DbContext
    {
        public EvaluationContext(DbContextOptions<EvaluationContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity Configurations
            modelBuilder.Entity<Request>()
                .ToTable<Request>("Requests", "dbo")
                .HasKey(x => x.Index);

            // Property Configurations
            modelBuilder.Entity<Request>()
                    .Property(s => s.Index)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

            modelBuilder.Entity<Request>()
                    .Property(s => s.Name)
                    .HasDefaultValue(string.Empty);

            modelBuilder.Entity<Request>()
                    .Property(s => s.Visits)
                    .HasDefaultValue(null)
                    .IsRequired(false);

            modelBuilder.Entity<Request>()
                    .Property(s => s.Date)
                    .HasDefaultValue(DateTime.UtcNow)
                    .IsRequired(true);

            // seed with EFCore > 2.1
            modelBuilder.BogusFakerSeed(100);
        }
    }
}

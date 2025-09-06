using Microsoft.EntityFrameworkCore;
using GymFlow.CustomerService.Domain.Entities;

namespace GymFlow.CustomerService.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Customer entity
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Phone).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Birthday).IsRequired(false);
                entity.Property(e => e.Gender).HasConversion<string>(); // Store enum as string
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.MembershipStatus).HasConversion<string>(); // Store enum as string
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP"); // Will be updated by trigger

                // Configure relationships (if navigation properties are added to Customer entity)
                // entity.HasMany(c => c.Checkins)
                //       .WithOne(c => c.Customer)
                //       .HasForeignKey(c => c.CustomerId);

                // entity.HasOne(c => c.MembershipPlan)
                //       .WithMany()
                //       .HasForeignKey(c => c.MembershipPlanId); // Assuming MembershipPlanId in Customer or CustomerId in MembershipPlan
            });

            // Map enums to PostgreSQL enum types
            modelBuilder.HasPostgresEnum<GymFlow.CustomerService.Domain.Enums.Gender>();
            modelBuilder.HasPostgresEnum<GymFlow.CustomerService.Domain.Enums.MembershipStatus>();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonManager.Domain.Persons;
using PersonManager.Infrastructure.EntityConfiguration;

namespace DeliverySystem.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> Person { get; set; }

        public AppDbContext(
            DbContextOptions dbContextOptions,
            IConfiguration configuration)
            : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("AppEntities");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

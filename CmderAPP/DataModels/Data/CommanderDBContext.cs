using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace DataModels.Data
{
    public class CommanderDBContext : DbContext
    {
        public CommanderDBContext(DbContextOptions<CommanderDBContext> options) : base(options) { }


        public DbSet<Command> Commands { get; set; }

        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>()
                        .HasData(
                            new Command
                            {
                                Id = 1,
                                Building = "WebApplication Project",
                                RestAPI = "Representational State Transfer Application Interface",
                                Project = "Commander Project"
                            });
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

    }
}

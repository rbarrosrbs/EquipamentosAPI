using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Equipamento> Equipamento { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
        public AppDbContext() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("equipamentos");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamento>().HasKey(c => c.Id);
            modelBuilder.Entity<Equipamento>().HasData(new Equipamento()
            {
                Id = 1,
                Nome = "Computador"
            });
        }
    }
}

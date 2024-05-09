using DevelopsToday.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DevelopsToday.DataLayer
{
    public  class DataContext : DbContext
    {
        private string _connectionString = ""; 

        public DataContext(string connectionString)
        {
            _connectionString = connectionString; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabData>()
                .HasIndex(e => e.PULocationID)
                .HasDatabaseName("PULocationID_Index");
        }

        public DbSet<CabData> CabData { get; set; }
    }
}

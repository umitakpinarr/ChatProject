using Microsoft.EntityFrameworkCore;

namespace ChatProject.Models.Context
{
    public class dbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=78.135.83.71;User Id=sa;Password=Sanane123;database=ChatProject;TrustServerCertificate=True");
            }
        }

        public DbSet<User> Users { get; set; }
    }
}

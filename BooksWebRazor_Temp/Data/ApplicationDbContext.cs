using BooksWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Categoty> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoty>().HasData(
                new Categoty { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Categoty { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Categoty { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}

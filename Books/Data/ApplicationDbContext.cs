using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        public DbSet<Book>books { get; set; }
        public  DbSet<Category>categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
        new Category { Id = 1,Name="Autobiography" },
          new Category { Id = 2,Name="Architecture" },
       new Category  {Id=3,Name=" Art"}
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}

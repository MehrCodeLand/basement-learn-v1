using basement_learn_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace basement_learn_v1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ): base( options )
    {
        
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Sport", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Languege", DisplayOrder = 2 },
            new Category { Id = 3 , Name = "Politic" , DisplayOrder = 5 }
            );
    }
}

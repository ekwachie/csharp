using csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp.DataAccess.app;
public class Config : DbContext {
    public Config(DbContextOptions<Config> options) : base(options)
    {
        
    }
    // property to create Categories DbTable
    public DbSet<Category> Categories { get; set; }

    // auto populating Category Table
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //    modelBuilder.Entity<Category>().HasData(
    //     new Category{Id = 1, Name = "Action", DisplayOrder = 1},
    //     new Category{Id = 2, Name = "SciFI", DisplayOrder = 2},
    //     new Category{Id = 3, Name = "History", DisplayOrder = 3}
    //    );
    // }
}
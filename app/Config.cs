using csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp.app;

public class Config : DbContext {
    public Config(DbContextOptions<Config> options) : base(options)
    {
        
    }
    // property to create Categories DbTable
    public DbSet<Category> Categories { get; set; }
}
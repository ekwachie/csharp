using csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp.app;

public class Config : DbContext {
    public Config(DbContextOptions<Config> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
}
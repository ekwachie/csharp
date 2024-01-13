
using csharp.DataAccess.app;
using csharp.Models;

namespace csharp.DataAccess;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private Config db;
    public CategoryRepository(Config conn) : base(conn)
    {
        db = conn;
    }

    public void Save()
    {
        db.SaveChanges();
    }

    public void Update(Category data)
    {
        db.Update(data);
    }
}

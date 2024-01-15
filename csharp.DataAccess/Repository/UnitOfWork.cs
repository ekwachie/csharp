using csharp.DataAccess.app;

namespace csharp.DataAccess;

public class UnitOfWork : IUnitOfWork
{
     public ICategoryRepository Category{get; private set;}
    private Config db;
    public UnitOfWork(Config conn)
    {
        db = conn;
        Category = new CategoryRepository(db);
    }
}

using csharp.Models;

namespace csharp.DataAccess;

public interface ICategoryRepository : IRepository<Category>
{
     void Update(Category data);
     void Save();
}

namespace csharp.DataAccess;

public interface IUnitOfWork
{
    // inject all Model Categories in here
    ICategoryRepository Category{get;}
}

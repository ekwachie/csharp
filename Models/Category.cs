using System.ComponentModel.DataAnnotations;

namespace csharp.Models;

public class Category
{

    /*
    * Creating properties; these will be used by the entity framework 
    * ( dotnet ef migrations add <name> and  dotnet ef database update ) 
    * to create Categories DbTable entities
    */
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string? Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,100, ErrorMessage = "The field Display Order must be between 1 - 100.")]
    public int DisplayOrder { get; set; }
}
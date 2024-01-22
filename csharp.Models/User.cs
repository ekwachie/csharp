using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace csharp.Models;
public class User
{
    public int UserId { get; set; }
    public string Fname { get; set; }
    public string Mname { get; set; }
    public string Lname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Dob { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }

}
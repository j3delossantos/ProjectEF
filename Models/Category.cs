using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace projectef.models;

public class Category
{
    //[Key]
    public Guid CategoryID {get; set;}

    //[Required]
   // [MaxLength(150)]
    public string Name {get; set;}

     public string Description {get; set;}

     public int Impact {get; set;}

     

     public ICollection<Task> tasks {get; set;}

}

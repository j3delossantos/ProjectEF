using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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

     [JsonIgnore]    

     public ICollection<Task> tasks {get; set;}

}

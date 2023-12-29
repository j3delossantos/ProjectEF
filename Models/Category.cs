namespace projectef.models;

public class Category
{
    public Guid CategoryID {get; set;}

    public string Name {get; set;}

     public string Desciption {get; set;}

     public ICollection<Task> tasks {get; set;}

}

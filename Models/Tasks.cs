namespace projectef.models;

public class Tasks
{
    public Guid TaskID {get; set;}

    public Guid CategoryID {get; set;}

    public string Title {get; set;}

    public string Desciption {get; set;}

    public  Priority TaskPriority {get; set;}

    public DateTime CreationDate {get; set;}

    public virtual Category Category {get; set;}

}

public enum Priority
{
    Low,
    Medium,
    Hight
}
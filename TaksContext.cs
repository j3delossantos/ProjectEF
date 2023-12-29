using Microsoft.EntityFrameworkCore;
using projectef.models;

namespace projectef;

public class TasksContext: DbContext
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Task> Tasks {get; set;}

    public TasksContext(DbContextOptions<TasksContext> options): base(options){}
}
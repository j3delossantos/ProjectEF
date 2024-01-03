using Microsoft.EntityFrameworkCore;
using projectef.models;

namespace projectef;

//[Keyless]
public class TasksContext: DbContext
{
    
    public DbSet<Category> Categories {get; set;}

    
    public DbSet<models.Task> Tasks {get; set;}

    public TasksContext(DbContextOptions<TasksContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add( new Category() 
        {   
            CategoryID =Guid.Parse("dfd661e0-369b-4f7d-8382-27dd541eaf02"), 
            Name = "Pending Activities", 
            Impact = 2, 
            Description=" All pending activities description"

        });

        categoriesInit.Add( new Category() 
        {   
            CategoryID =Guid.Parse("dfd661e0-369b-4f7d-8382-27dd541eaf03"), 
            Name = "Upcoming events", 
            Impact = 5, 
            Description=" Meetings, birthdates and appointments"

        });
        
        modelBuilder.Entity<Category>(Category =>
        {
            Category.ToTable("Category");
            Category.HasKey(p=> p.CategoryID);
            Category.Property(p=> p.Name).IsRequired().HasMaxLength(150);
            Category.Property(p=> p.Description);
            Category.Property(p=> p.Impact);
            Category.HasData(categoriesInit);

        });


         List<models.Task> tasksInit = new List<models.Task>();
        tasksInit.Add( new models.Task() 
        {   
            TaskID =Guid.Parse("dfd661e0-369b-4f7d-8382-27dd541eaf50"), 
            CategoryID = Guid.Parse("dfd661e0-369b-4f7d-8382-27dd541eaf02"),
            Title = "Call the insurance company",              
            Description =" Call for a quote on the tenant insurance",
            TaskPriority = Priority.Medium,
            CreationDate = DateTime.Now           

        });

        tasksInit.Add( new models.Task() 
        {   
            TaskID =Guid.Parse("dfd661e0-369b-4f7d-8382-27dd541eaf51"), 
            CategoryID = Guid.Parse("dfd661e0-369b-4f7d-8382-27dd541eaf03"),
            Title = "Job Interview",              
            Description =" Job interview at Boeing on Friday ",
            TaskPriority = Priority.Hight,
            CreationDate = DateTime.Now           

        });

      

        modelBuilder.Entity<models.Task>(Task =>
        {
            Task.ToTable("Task");
            Task.HasKey(p=> p.TaskID);
            Task.HasOne(p=> p.Category).WithMany(p=> p.tasks).HasForeignKey(p=> p.CategoryID);
            Task.Property(p=> p.Title).IsRequired().HasMaxLength(150);
            Task.Property(p=> p.Description);
            Task.Property(p=> p.TaskPriority);
            Task.Property(p=> p.CreationDate);           
            Task.Ignore(p=> p.Summary);
            Task.HasData(tasksInit);



           
            //Task.HasAlternateKey(p=> p.CategoryID);
            

        });
       // base.OnModelCreating(modelBuilder);
    }
}
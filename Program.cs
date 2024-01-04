using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p =>  p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("TasksCN"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) => 
{
    
   dbContext.Database.EnsureCreated();
   return Results.Ok("In Memory database: " + dbContext.Database.IsInMemory());
    
    

});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext)=>
{
   //return Results.Ok(dbContext.Tasks.Include(p=> p.Category).Where(p=> p.TaskPriority == Priority.Hight));
   return Results.Ok(dbContext.Tasks.Include(p=> p.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] projectef.models.Task task)=>
{
   task.TaskID = Guid.NewGuid();
   task.CreationDate = DateTime.Now;
   await dbContext.AddAsync(task);
   await dbContext.SaveChangesAsync();
   return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] projectef.models.Task task, [FromRoute] Guid id)=>
{
   var currentTask =dbContext.Tasks.Find(id);

   if (currentTask != null)
   {
      currentTask.CategoryID = task.CategoryID;
      currentTask.Title = task.Title;
      currentTask.TaskPriority = task.TaskPriority;
      currentTask.Description = task.Description;

      await dbContext.SaveChangesAsync();
      return Results.Ok();
   }
   else{
      return Results.NotFound();
   }

   
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id)=>
{
   var currentTask =dbContext.Tasks.Find(id);

   if (currentTask != null)
   {
      dbContext.Remove(currentTask);
      await dbContext.SaveChangesAsync();
      return Results.Ok();

   } else{
      return Results.NotFound();
   }
});

app.Run();

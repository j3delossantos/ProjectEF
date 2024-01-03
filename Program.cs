using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

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

app.Run();

// dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// dotnet add package Microsoft.EntityFrameworkCore.Design
// dotnet add package Microsoft.EntityFrameworkCore.Tools

// Instructions:

// To update the database do the following:
//      Navigate to the project folder (not the solution folder) in a terminal
//      run: dotnet ef migrations add [MigrationName]
//          if you get any errors, run "dotnet ef remove migration", then try again
//      then run: dotnet ef database update
//          if you get any errors, run "dotnet ef database drop", then try again
//          if that doesn't work, check the output and review your db migration

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

// Create the database context
var dbContext = new AppDbContext();

// Ensure the database is created
dbContext.Database.EnsureCreated();

// You can put your own code right here:

// Free the resources used by the database context
dbContext.Dispose();

// Define Database Context
public class AppDbContext : DbContext
{
    // Add your DbSets here
    DbSet<Test1> test1;
    DbSet<Test2> test2;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the database context to use SQLite
        optionsBuilder.UseSqlite("Data Source=app.db");
        
        // Uncomment this line to log SQL statements to the console
        // optionsBuilder.LogTo(Console.WriteLine);
        
        // You can put your custom configuration here
    }
}

// Replace these with your own classes
class Test1
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Test2
{
    [Key]
    public int Id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
}
using Microsoft.EntityFrameworkCore;
using PrepStack.Models;

namespace PrepStack.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        // This 'DbSet' tells C# that our 'Question' class maps to the 'Questions' table in SQL

        public DbSet<Question> Questions { get; set; }
    }
}

//If an interviewer asks: "What is a DbContext?"

//Answer: "It is the primary class that coordinates Entity Framework functionality for a given data model.
//It handles the database connection and is used to query and save data.

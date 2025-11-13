using System;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data;

public class ApiDbContext : DbContext // This DbContext Class comes from EF Core Package
{
    // This constructor takes the DB provider and connection string, from the Program.cs file.
    // Your DbContext cannot perform without this DbContextOptions
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }
    
    // This maps my TaskItem model properties to a table via the DbContext Class that communicates with my DB
    public DbSet<TaskItem> TaskItems { get; set; }
}

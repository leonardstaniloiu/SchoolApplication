using Microsoft.EntityFrameworkCore;
using School.Features.Assignments.Models;

namespace School.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    public DbSet<AssignmentModel> Assignments { get; set; }
    
    
            
        
}
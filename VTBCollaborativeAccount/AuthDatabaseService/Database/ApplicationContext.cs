using AuthDatabaseService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthDatabaseService.Database;

public class ApplicationContext : DbContext
{
    public DbSet<UserModel> users { get; set; }
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server = localhost; Database = auth; Uid = postgres; Pwd = root;");
    }
}
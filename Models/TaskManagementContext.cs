
using Microsoft.EntityFrameworkCore;

namespace TaskManagmentApi.Models
{
    public class TaskManagmentContext:DbContext
    {
        public DbSet<Board> Boards{get;set;}
        public DbSet<Task> Tasks{get;set;}
        public DbSet<Developer> Developers{get;set;}

        public TaskManagmentContext(DbContextOptions options):base(options)
        {

        }
    }
}
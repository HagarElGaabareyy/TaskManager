using Microsoft.EntityFrameworkCore;
using Task = TaskManagerApi.Models.Task;  // Use alias for Task model


namespace TaskManagerApi.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } // Define your DbSet properties here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here
        }
    }
}

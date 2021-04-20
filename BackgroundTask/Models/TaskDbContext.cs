using Microsoft.EntityFrameworkCore;

namespace BackgroundTask.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileModel> FileModel { get; set; }
    }
}

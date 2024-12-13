using Microsoft.EntityFrameworkCore;
using SharedLibrary.Entity;

namespace SharedLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<StProgram> StPrograms { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}

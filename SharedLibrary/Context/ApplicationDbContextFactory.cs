using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SharedLibrary.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = "Data Source=DissertionThemes.db";

            var relativePath = "DissertionThemes.db";
            var absolutePath = Path.GetFullPath(relativePath);

            optionsBuilder.UseSqlite(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

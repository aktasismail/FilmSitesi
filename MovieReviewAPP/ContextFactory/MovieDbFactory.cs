using DataAccessLayer.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MovieReviewAPP.ContextFactory
{
    public class MovieDbFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MovieDbContext>()
                .UseSqlServer(configuration.GetConnectionString("MovieConnection"),
                mgrtn => mgrtn.MigrationsAssembly("MovieReviewAPP"));
            return new MovieDbContext(builder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Factorials.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
    }
}

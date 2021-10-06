using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factorials.Models
{
    public class RepositoryContext: DbContext
    {
        public DbSet<Number> Numbers { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
    }
}

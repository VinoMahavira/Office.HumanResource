using Microsoft.EntityFrameworkCore;
using Office.HumanResource.Core.Entities;

namespace Office.HumanResource.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
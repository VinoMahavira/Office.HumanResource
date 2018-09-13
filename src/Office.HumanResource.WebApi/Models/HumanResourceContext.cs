using Microsoft.EntityFrameworkCore;

namespace Office.HumanResource.WebApi.Models
{
    public class HumanResourceContext : DbContext
    {   
        public HumanResourceContext(DbContextOptions<HumanResourceContext> options)
            : base(options)
        {

        }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
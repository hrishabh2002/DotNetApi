using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entities;

namespace WebApplication2.Data
{
    public class ApplicationDb:DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options):base(options) 
        {
            
        }

        public DbSet<Employees> Employees { get; set; }
    }
}

using burulas.Entity;
using Microsoft.EntityFrameworkCore;

namespace burulas.Data.Concrete.EfCore
{
    public class BurulasContext : DbContext
    {
        public BurulasContext(DbContextOptions<BurulasContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
    }

}
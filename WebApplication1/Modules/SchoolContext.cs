using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modules
{
    public class SchoolContext : DbContext
    {
        // student is an entity; Prop for a new method
        //DBSet and then the type
        public DbSet<Student> Students { get; set; }
        //ctor, constructor shortcut
        public SchoolContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}

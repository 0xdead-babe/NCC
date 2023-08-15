using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    //provides an abstraction over the database. Manages the database connection and interactions with it
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }

        //this will be the table name in the database
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher{ get; set; }

    }
}

using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI
{
    public class ApplicationDbContext : DbContext
    {

        // constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        // add models to database context
        public virtual DbSet<StudentModel> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentDetailApi.Models;

namespace StudentDetailApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options)
        {
            
        }
        public DbSet<Student> student { get; set; }
    }
}

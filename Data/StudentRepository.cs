using StudentDetailApi.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentDetailApi.Data
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

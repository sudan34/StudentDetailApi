using StudentDetailApi.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentDetailApi.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _dbContext.student.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.student.FindAsync(id);
        }
        public async Task<Student> CreateStudent(Student student)
        {
            _dbContext.student.Add(student);
             await _dbContext.SaveChangesAsync();
            return student;
        }

        
        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _dbContext.student.FindAsync(id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Address = student.Address;
                existingStudent.Email = student.Email;
            }
            else
            {
                return null;
            }
            await _dbContext.SaveChangesAsync();
            return existingStudent;
        }
        public async Task DeleteStudent(int id)
        {
            var student = await _dbContext.student.FindAsync(id);
            if (student != null)
            {
                _dbContext.student.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

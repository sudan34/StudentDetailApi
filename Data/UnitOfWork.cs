using StudentDetailApi.Models;

namespace StudentDetailApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            StudentRepository = new Repository<Student>(_dbContext);
        }
        public IStudentRepository StudentRepository { get; private set; }

        // Add other repository properties
        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


        
    }
}

namespace StudentDetailApi.Data
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }

        Task<int> SaveChangeAsync();
    }
}

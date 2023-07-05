using System.ComponentModel.DataAnnotations;

namespace StudentDetailApi.Data
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}

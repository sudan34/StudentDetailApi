using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDetailApi.Data;
using StudentDetailApi.Models;

namespace StudentDetailApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentRepository.GetAllStudent();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            var createdStudent = await _studentRepository.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            var updatedStudent = await _studentRepository.UpdateStudent(id, student);
            if (updatedStudent == null)
                return NotFound();

            return Ok(updatedStudent);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
            return NoContent();
        }
    }
}

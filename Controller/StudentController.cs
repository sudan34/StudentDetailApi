using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetAll();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var student = await _unitOfWork.StudentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(student);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var createdStudent = await _unitOfWork.StudentRepository.Create(student);
            await _unitOfWork.SaveChangeAsync();
            var createdStudentDto = _mapper.Map<StudentDto>(createdStudent);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudentDto.Id }, createdStudentDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.Id = id;
            var updatedStudent = await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.SaveChangeAsync();
            var updatedStudentDto = _mapper.Map<StudentDto>(updatedStudent);
            return Ok(updatedStudentDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _unitOfWork.StudentRepository.GetById(id);
            if (student == null)
                return NotFound();

            await _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.SaveChangeAsync();
            return NoContent();
        }
    }
}

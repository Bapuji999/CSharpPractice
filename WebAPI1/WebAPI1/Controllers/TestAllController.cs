using Microsoft.AspNetCore.Mvc;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestAllController : ControllerBase
    {
        private readonly IStudents _st;
        public TestAllController(IStudents st)
        {
            _st = st;
        }
        [HttpGet]
        [Route("Welocome")]
        public string Welocome()
        {
            return "Welcome";
        }
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            if (_st.students.Any())
            {
                return Ok(_st.students);
            }
            else
            {
                return NotFound("No students found");
            }
        }
        [HttpGet]
        [Route("GetStudent")]
        public IActionResult GetStudent(int Id)
        {
            var student = _st.students.FirstOrDefault(x => x.Id == Id);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound("No student found");
            }
        }
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid student data");
            }
            _st.students.Add(student);
            return StatusCode(200, "Student added successfully");
        }
        [HttpPatch]
        [Route("RenameStudent")]
        public IActionResult RemaneStudent([FromQuery] int Id, string Name)
        {
            var student = _st.students.FirstOrDefault(x => x.Id == Id);
            if (student == null)
            {
                return BadRequest($"No Student With Id {Id}");
            }
            student.Name = Name;
            var index = _st.students.FindIndex(student => student.Id == Id);
            _st.students[index] = student;
            return StatusCode(200, "Student Renamed successfully");
        }
        [HttpPut]
        [Route("ChangeStudent")]
        public IActionResult ChangeStudent(int Id, [FromBody] Student newStudent)
        {
            var oldStudent = _st.students.FirstOrDefault(x => x.Id == Id);
            if (oldStudent == null)
            {
                return BadRequest($"No Student With Id {Id}");
            }
            var index = _st.students.FindIndex(student => student.Id == Id);
            newStudent.Id = Id;
            _st.students[index] = newStudent;
            return StatusCode(200, "Student Changed successfully");
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult DeleteStudent(int Id)
        {
            var student = _st.students.FirstOrDefault(x => x.Id == Id);
            if (student == null)
            {
                return BadRequest($"No Student With Id {Id}");
            }
            _st.students.Remove(student);
            return Ok("Student Deleted");
        }
        [HttpHead]
        [Route("StudentClassInHead")]
        public IActionResult StudentClassInHead(int id)
        {
            var student = _st.students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found");
            }
            Response.Headers.Add("class", student.Class.ToString("R"));
            return Ok();
        }
    }
}

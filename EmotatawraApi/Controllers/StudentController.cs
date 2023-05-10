using DataBase.Context;
using DataBase.Entity;
using Methods.InterFaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmotatawraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Student> _student;

        public StudentController(DBAContext context, IGenericRepository<Student> student)
        {
            _context = context;
            _student = student;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetAllStudents()
        {
            var result = await _student.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetRoomById(int id)
        {
            var result = await _student.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<IReadOnlyList<Student>>> AddRoom([FromBody] Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Student>>> DeleteStudent(int id)
        {
            var result = await _student.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _student.Delete(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Student>>> UpdateStudent(int id)
        {
            var result = await _student.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _student.Update(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}

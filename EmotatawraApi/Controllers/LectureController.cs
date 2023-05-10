using DataBase.Context;
using DataBase.Entity;
using Methods.InterFaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmotatawraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LectureController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Lecture> _lecture;

        public LectureController(DBAContext context, IGenericRepository<Lecture> lecture)
        {
            _context = context;
            _lecture = lecture;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Lecture>>> GetAllLecture()
        {
            var result = await _lecture.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<Lecture>>> GetLectureById(int id)
        {
            var result = await _lecture.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Add Lecture")]
        public async Task<ActionResult<IReadOnlyList<Lecture>>> AddLecture([FromBody] Lecture lecture)
        {
            var result = await _context.Lectures.AddAsync(lecture);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Lecture>>> DeleteLecture(int id)
        {
            var result = await _lecture.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _lecture.Delete(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Lecture>>> UpdateLecture(int id)
        {
            var result = await _lecture.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _lecture.Update(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}

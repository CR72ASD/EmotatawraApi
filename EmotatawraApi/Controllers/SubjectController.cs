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
    public class SubjectController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Subject> _subject;

        public SubjectController(DBAContext context, IGenericRepository<Subject> subject)
        {
            _context = context;
            _subject = subject;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Subject>>> GetAllSubjects()
        {
            var result = await _subject.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<Subject>>> GetSubjectById(int id)
        {
            var result = await _subject.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("AddSubject")]
        public async Task<ActionResult<IReadOnlyList<Subject>>> AddSubject([FromBody] Subject subject)
        {
            var result = await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Subject>>> DeleteSubject(int id)
        {
            var result = await _subject.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _subject.Delete(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Subject>>> UpdateSubject(int id)
        {
            var result = await _subject.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _subject.Update(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}

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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Instractor_SubjectController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<InstractorSubject> _repository;

        public Instractor_SubjectController(DBAContext context, IGenericRepository<InstractorSubject> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<InstractorSubject>>> GetAllInstractorSubject()
        {
            var result = await _repository.GetAllAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<InstractorSubject>>> GetInstractor_SubjectId(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            return Ok();
        }

        [HttpPost("Add Instractor_Subject")]
        public async Task<ActionResult<IReadOnlyList<InstractorSubject>>> AddInstractor_Subject([FromBody] InstractorSubject instractor_Subject)
        {
            var result = await _context.AddAsync(instractor_Subject);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<InstractorSubject>>> DeleteInstractorSubject(int id)
        {
            var deleteData = await _repository.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _repository.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<InstractorSubject>>> UpdateInstractorSubject(InstractorSubject instractor_Subject)
        {
            var updateData = await _repository.GetAllAsync();
            if (instractor_Subject is null)
                return NotFound();
            _context.Update(updateData);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

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
    public class QuizMarkController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<QuizMark> _quiz;

        public QuizMarkController(DBAContext context, IGenericRepository<QuizMark> quiz)
        {
            _context = context;
            _quiz = quiz;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<QuizMark>>> GetById(int id,QuizMark quiz)
        {
            if (quiz.StudentCodeNavigation is null) 
                return NotFound();
            var result = await _quiz.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<IReadOnlyList<QuizMark>>> Add([FromBody] QuizMark quiz)
        {
            var result = await _context.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<QuizMark>>> Delete(int id)
        {
            if (id == null)
                return NotFound();
            var deleteData = await _quiz.GetByIdAsync(id);
            _quiz.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<QuizMark>>> Update(QuizMark quiz)
        {
            if (quiz is null)
                return NotFound();
            var updateData = await _quiz.GetAllAsync();
            _context.Update(updateData);
            await _context.SaveChangesAsync();
            return Ok(updateData);
        }
    }
}

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
    public class InstractorController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Instractor> _instractor;

        public InstractorController(DBAContext context, IGenericRepository<Instractor> instractor)
        {
            _context = context;
            _instractor = instractor;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Instractor>>> GetAllInstractor()
        {
            var result = await _instractor.GetAllAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<Instractor>>> GetInstractorById(int id)
        {
            var result = await _instractor.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Add Instractor")]
        public async Task<ActionResult<IReadOnlyList<Instractor>>> Addinstractor([FromBody] Instractor instractor)
        {
            var result = await _context.Instractors.AddAsync(instractor);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Instractor>>> DeleteInstractor(int id)
        {
            var result = await _instractor.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _instractor.Delete(result);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Instractor>>> UpdateInstractor(int id)
        {
            var result = await _instractor.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _instractor.Update(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}

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
    [Authorize]
    public class AcadmicYearController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<AcademicYear> _acadmic;

        public AcadmicYearController(DBAContext context, IGenericRepository<AcademicYear> acadmic)
        {
            _context = context;
            _acadmic = acadmic;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<AcademicYear>>> GetAllAcadmicYear()
        {
            var result = await _acadmic.GetAllAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<AcademicYear>>> GetAcadmicYearById(int id)
        {
            var result = await _acadmic.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("AddAcadmicYear")]
        public async Task<ActionResult<IReadOnlyList<AcademicYear>>> AddAcademicYear([FromBody] AcademicYear academicYear)
        {
            var result = await _context.AddAsync(academicYear);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<AcademicYear>>> DeleteAcademicYear(int id)
        {
            var deleteData = await _acadmic.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _acadmic.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<AcademicYear>>> UpdateAcademicYear(AcademicYear academicYear)
        {
            var updateData = await _acadmic.GetAllAsync();
            if (academicYear is null)
                return NotFound();
            _context.Update(updateData);
            await _context.SaveChangesAsync();
            return Ok(updateData);
        }
    }
}

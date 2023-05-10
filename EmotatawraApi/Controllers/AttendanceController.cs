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
    public class AttendanceController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Attendance> _attendance;

        public AttendanceController(DBAContext context, IGenericRepository<Attendance> attendance)
        {
            _context = context;
            _attendance = attendance;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<IReadOnlyList<Attendance>>> Add([FromBody] Attendance attendance)
        {
            var result = await _context.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Attendance>>> Delete(int id)
        {
            var deleteData = await _attendance.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _attendance.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Attendance>>> Update(Attendance attendance)
        {
            var updateData = await _attendance.GetAllAsync();
            if (attendance is null)
                return NotFound();
            _context.Update(updateData);
            await _context.SaveChangesAsync();
            return Ok(updateData);
        }
    }
}

using DataBase.Context;
using DataBase.Entity;
using Methods.InterFaces;
using Methods.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ElmotatawraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Admin> _admin;
        public AdminController(DBAContext context,IGenericRepository<Admin> admin)
        {
            _context = context;
            _admin = admin;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Admin>>> GetAllAcadmicYear()
        {
            var result = await _admin.GetAllAsync();
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<Admin>>> GetAcadmicYearById(int id)
        {
            var result = await _admin.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            return Ok();
        }

        [HttpPost("Add Admin")]
        public async Task<ActionResult<IReadOnlyList<Admin>>> AddAcademicYear([FromBody] Admin admin)
        {
            var result = await _context.AddAsync(admin);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Admin>>> DeleteAcademicYear(int id)
        {
            var deleteData = await _admin.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _admin.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Admin>>> UpdateAcademicYear(Admin admin)
        {
            var updateData = await _admin.GetAllAsync();
            if (admin is null)
                return NotFound();
            _context.Update(updateData);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

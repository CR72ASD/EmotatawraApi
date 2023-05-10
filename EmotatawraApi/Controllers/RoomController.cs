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
    public class RoomController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Room> _room;

        public RoomController(DBAContext context, IGenericRepository<Room> room)
        {
            _context = context;
            _room = room;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Room>>> GetAllRooms()
        {
            var result = await _room.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IReadOnlyList<Room>>> GetRoomById(int id)
        {
            var result = await _room.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("Add Room")]
        public async Task<ActionResult<IReadOnlyList<Room>>> AddRoom([FromBody] Room room)
        {
            var result = await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Room>>> DeleteRoom(int id)
        {
            var result = await _room.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _room.Delete(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<IReadOnlyList<Room>>> UpdateRoom(int id)
        {
            var result = await _room.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            _room.Update(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}

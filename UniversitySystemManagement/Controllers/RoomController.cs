using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.CommandExecuters;
using UniversityManagementSystem.Commands;


[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly DataContext _context;

    public RoomController(DataContext context)
    {
        _context = context;
    }

    // GET: api/Room
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        var rooms = await _context.Room.ToListAsync();

        if (rooms == null || !rooms.Any())
        {
            return NotFound();
        }

        return Ok(rooms);
    }

    // GET: api/Room/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _context.Room.FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return room;
    }

    // POST: api/Room
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(Room room)
    {
        var createCommand = new CreateRoomCommand(_context, room);
        var executor = new RoomCommandExecutor();
        var success = await executor.ExecuteCommandAsync(createCommand);

        if (!success)
        {
            return StatusCode(500, "Failed to create room");
        }

        return CreatedAtAction(nameof(GetRoom), new { id = room.room_number }, room);
    }

    // PUT: api/Room/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(int id, Room room)
    {
        var updateCommand = new UpdateRoomCommand(_context, id, room);
        var executor = new RoomCommandExecutor();
        var success = await executor.ExecuteCommandAsync(updateCommand);

        if (!success)
        {
            return StatusCode(500, "Failed to update room");
        }

        return NoContent();
    }

    // DELETE: api/Room/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var deleteCommand = new DeleteRoomCommand(_context, id);
        var executor = new RoomCommandExecutor();
        var success = await executor.ExecuteCommandAsync(deleteCommand);

        if (!success)
        {
            return StatusCode(500, "Failed to delete room");
        }

        return NoContent();
    }
}

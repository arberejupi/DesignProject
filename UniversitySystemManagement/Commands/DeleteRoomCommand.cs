namespace UniversityManagementSystem.Commands
{
    // DeleteRoomCommand.cs
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using UniversityManagementSystem.Data;
    using UniversityManagementSystem.Models;

    public class DeleteRoomCommand : IRoomCommand
    {
        private readonly DataContext _context;
        private readonly int _roomId;

        public DeleteRoomCommand(DataContext context, int roomId)
        {
            _context = context;
            _roomId = roomId;
        }

        public async Task<bool> ExecuteAsync()
        {
            try
            {
                var room = await _context.Room.FindAsync(_roomId);

                if (room == null)
                {
                    return false; // Room not found
                }

                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log or handle exceptions
                return false;
            }
        }
    }

}

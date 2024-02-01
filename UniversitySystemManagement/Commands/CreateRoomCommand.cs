namespace UniversityManagementSystem.Commands
{
    // CreateRoomCommand.cs
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using UniversityManagementSystem.Data;
    using UniversityManagementSystem.Models;

    public class CreateRoomCommand : IRoomCommand
    {
        private readonly DataContext _context;
        private readonly Room _room;

        public CreateRoomCommand(DataContext context, Room room)
        {
            _context = context;
            _room = room;
        }

        public async Task<bool> ExecuteAsync()
        {
            try
            {
                _context.Room.Add(_room);
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

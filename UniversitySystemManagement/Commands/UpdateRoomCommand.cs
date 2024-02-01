namespace UniversityManagementSystem.Commands
{
    // UpdateRoomCommand.cs
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using UniversityManagementSystem.Data;
    using UniversityManagementSystem.Models;

    public class UpdateRoomCommand : IRoomCommand
    {
        private readonly DataContext _context;
        private readonly int _roomId;
        private readonly Room _updatedRoom;

        public UpdateRoomCommand(DataContext context, int roomId, Room updatedRoom)
        {
            _context = context;
            _roomId = roomId;
            _updatedRoom = updatedRoom;
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

                // Apply changes from _updatedRoom to the existing room entity
                room.capacity = _updatedRoom.capacity;
                room.equipment = _updatedRoom.equipment;
                room.building_name = _updatedRoom.building_name;
                room.floor_number = _updatedRoom.floor_number;
                room.room_type = _updatedRoom.room_type;

                _context.Entry(room).State = EntityState.Modified;
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

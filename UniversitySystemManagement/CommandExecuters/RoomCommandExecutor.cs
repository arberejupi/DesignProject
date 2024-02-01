namespace UniversityManagementSystem.CommandExecuters
{// RoomCommandExecutor.cs
    using System.Threading.Tasks;
    using UniversityManagementSystem.Commands;

    public class RoomCommandExecutor
    {
        public async Task<bool> ExecuteCommandAsync(IRoomCommand command)
        {
            return await command.ExecuteAsync();
        }
    }

}

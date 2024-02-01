namespace UniversityManagementSystem.Commands
{
    using System.Threading.Tasks;
    using UniversityManagementSystem.Models;

    public interface IRoomCommand
    {
        Task<bool> ExecuteAsync();
    }
}

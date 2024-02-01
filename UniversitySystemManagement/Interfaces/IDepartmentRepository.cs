using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task<bool> UpdateDepartmentAsync(int id, Department department);
        Task<bool> DeleteDepartmentAsync(int id);
    }

}

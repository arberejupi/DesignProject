using UniversityManagementSystem.Interfaces;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department> GetDepartmentAsync(int id)
        {
            return await _context.Department.FindAsync(id);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Department.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> UpdateDepartmentAsync(int id, Department department)
        {
            if (id != department.department_id)
            {
                return false;
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

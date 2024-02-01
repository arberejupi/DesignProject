using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseAsync(int id);
        Task<Course> AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(int id, Course course);
        Task<bool> DeleteCourseAsync(int id);
        bool CourseExists(int id);
    }
}

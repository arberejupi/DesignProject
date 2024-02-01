using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Interfaces;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Course.FindAsync(id);
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> UpdateCourseAsync(int id, Course course)
        {
            if (id != course.course_id)
            {
                return false;
            }

            _context.Entry(course).State = EntityState.Modified;

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

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return false;
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.course_id == id);
        }
    }
}

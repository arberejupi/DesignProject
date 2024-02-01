using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniversityManagementSystem.Data; // Import your DbContext
using UniversityManagementSystem.Models;
using Microsoft.Extensions.Logging;
using UniversityManagementSystem.Repositories;
using UniversityManagementSystem.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILogger<CourseController> _logger;

    public CourseController(ICourseRepository courseRepository, ILogger<CourseController> logger)
    {
        _courseRepository = courseRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
    {
        var courses = await _courseRepository.GetAllCoursesAsync();

        if (courses == null || !courses.Any())
        {
            return NotFound();
        }

        return courses.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _courseRepository.GetCourseAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        return course;
    }

    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
        var addedCourse = await _courseRepository.AddCourseAsync(course);

        return CreatedAtAction("GetCourse", new { id = addedCourse.course_id }, addedCourse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(int id, Course course)
    {
        var result = await _courseRepository.UpdateCourseAsync(id, course);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var result = await _courseRepository.DeleteCourseAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

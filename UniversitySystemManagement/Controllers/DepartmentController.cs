using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementSystem.Interfaces;
using UniversityManagementSystem.Models;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(IDepartmentRepository departmentRepository, ILogger<DepartmentController> logger)
    {
        _departmentRepository = departmentRepository;
        _logger = logger;
    }

    // GET: api/Department
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        var departments = await _departmentRepository.GetDepartmentsAsync();

        if (departments == null || !departments.Any())
        {
            return NotFound();
        }

        return departments.ToList();
    }

    // GET: api/Department/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartment(int id)
    {
        var department = await _departmentRepository.GetDepartmentAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        return department;
    }

    // POST: api/Department
    [HttpPost]
    public async Task<ActionResult<Department>> PostDepartment(Department department)
    {
        var addedDepartment = await _departmentRepository.AddDepartmentAsync(department);

        return CreatedAtAction(nameof(GetDepartment), new { id = addedDepartment.department_id }, addedDepartment);
    }

    // PUT: api/Department/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartment(int id, Department department)
    {
        var result = await _departmentRepository.UpdateDepartmentAsync(id, department);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // DELETE: api/Department/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var result = await _departmentRepository.DeleteDepartmentAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

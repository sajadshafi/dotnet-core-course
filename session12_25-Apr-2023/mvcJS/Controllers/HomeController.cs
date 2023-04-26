using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcJS.Models;

namespace mvcJS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
        _db = new(_config);
    }

    public async Task<IActionResult> Index()
    {
        List<Employee> Employees = await _db.Employees.ToListAsync();
        return View(Employees);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(Employee emp)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        try
        {
            await _db.Employees.AddAsync(emp);
            await _db.SaveChangesAsync();
            return Ok(emp);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEmployee(int? id)
    {
        if (id == null)
            return BadRequest();
        try
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return Ok(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}

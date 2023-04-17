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
    public IActionResult AddEmployee(Employee emp) {
        Console.WriteLine("Employee: ", emp.Name);
        return Ok(emp.Name);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

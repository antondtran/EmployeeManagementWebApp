using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly DBContext dBContext1;

    public HomeController(ILogger<HomeController> logger, DBContext dBContext1)
    {
        _logger = logger;
        this.dBContext1 = dBContext1;
    }

    [HttpGet]
    public async Task<IActionResult> Index(){
        var employees = await dBContext1.Employees.ToListAsync();
        return View(employees);
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

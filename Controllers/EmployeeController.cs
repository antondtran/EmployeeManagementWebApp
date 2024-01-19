using EmployeeApplication;
using EmployeeApplication.Controllers;
using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class EmployeeController : Controller{

    private readonly DBContext dBContext;

    public EmployeeController(DBContext dBContext){
        this.dBContext = dBContext;
    }



    [HttpGet]
    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest){
        var employee = new Employee(){
            id = Guid.NewGuid(),
            firstName = addEmployeeRequest.firstName,
            lastName = addEmployeeRequest.lastName,
            email = addEmployeeRequest.email
        };

        await dBContext.Employees.AddAsync(employee);
        await dBContext.SaveChangesAsync();

        return RedirectToAction("Add");

    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateEmployeeViewModel updateEmployeeRequest){

        var employee = await dBContext.Employees.FindAsync(updateEmployeeRequest.id);


        if(employee != null){
            employee.firstName = updateEmployeeRequest.firstName;
            employee.lastName = updateEmployeeRequest.lastName;
            employee.email = updateEmployeeRequest.email;

            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        
        return RedirectToAction("Index", "Home");


    }

    [HttpGet]
    public async Task<IActionResult> View(Guid id){
        var employee = await dBContext.Employees.FirstOrDefaultAsync(x => x.id == id);


        if (employee != null){
            
            var viewModel = new UpdateEmployeeViewModel(){
            id = employee.id,
            firstName = employee.firstName,
            lastName = employee.lastName,
            email = employee.email


        };

        return await Task.Run(() => View("View", viewModel));
        }
        
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult delete(UpdateEmployeeViewModel updateEmployeeRequest){
        
        var employee = dBContext.Employees.Find(updateEmployeeRequest.id);

if (employee != null){
dBContext.Employees.Remove(employee);
        dBContext.SaveChanges();

        return RedirectToAction("Index", "Home");
}
        
return RedirectToAction("Index", "Home");
    }
}
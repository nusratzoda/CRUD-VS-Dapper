using Domain;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : Microsoft.AspNetCore.Mvc.ControllerBase
{
    private StudentServices _studentsservices;
    public StudentController()
    {
        _studentsservices = new StudentServices();
    }
    [HttpGet]
    public List<Students> GetStudents()
    {
        return _studentsservices.GetStudents();
    }
    [HttpPost]
    public int AddStudents(Students students)
    {
        return _studentsservices.AddStudents(students);
    }

    [HttpPut]
    public int UpdateStudents(Students students)
    {
        return _studentsservices.UpdateStudents(students);
    }
    [HttpDelete]
    public int GetStudents(int id)
    {
        return _studentsservices.DeleteStudents(id);
    }
}

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Options;
using Student_Management_Sys.Authorization;
using Student_Management_Sys.Helpers;
using Student_Management_Sys.Models;
using Student_Management_Sys.Services;
namespace Student_Management_Sys.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private IStudentService _studentService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public StudentController(
        IStudentService studentService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _studentService = studentService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }


    [AllowAnonymous]
    //API Controller function for register a student 
    [HttpPost("register")]
    public IActionResult StudentRegister(StudentRegister model)
    {
        _studentService.StudentRegister(model);
        return Ok(new { message = "Registration successful" });
    }
    //API Controller function for get all student list
    [HttpGet("AllStudents")]
    public IActionResult GetAll()
    {
        var students = _studentService.GetAll();
        return Ok(students);
    }
    //API Controller function for get student by it's ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _studentService.GetById(id);
        return Ok(student);
    }
    //API Controller function for update student by it's ID
    [HttpPut("{id}")]
    public IActionResult StudentUpdate(int id, StudentUpdate model)
    {
        _studentService.StudentUpdate(id, model);
        return Ok(new { message = "Student updated successfully" });
    }
    //API Controller function for delete student by it's ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _studentService.StudentDelete(id);
        return Ok(new { message = "Student deleted successfully" });
    }
}
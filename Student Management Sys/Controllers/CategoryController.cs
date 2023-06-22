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
public class CategoryController : ControllerBase
{
    private ICategoryService _categoryService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public CategoryController(
        ICategoryService categoryService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }
    [AllowAnonymous]
    //API Controller function for create category
    [HttpPost("create")]
    public IActionResult CategoryCreate(CategoryCreate model)
    {
        _categoryService.CategoryCreate(model);
        return Ok(new { message = "CreateCategory successful" });
    }
    //API Controller function for get category list
    [HttpGet("AllCategories")]
    public IActionResult GetAll()
    {
        var categories = _categoryService.GetAll();
        return Ok(categories);
    }
    //API Controller function for get category by it's ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetById(id);
        return Ok(category);
    }
    //API Controller function for delete category by it's ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _categoryService.CategoryDelete(id);
        return Ok(new { message = "Category deleted successfully" });
    }
}

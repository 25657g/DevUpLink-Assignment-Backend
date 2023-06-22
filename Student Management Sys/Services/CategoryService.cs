namespace Student_Management_Sys.Services;
using AutoMapper;
using Student_Management_Sys.Entities;
using Student_Management_Sys.Helpers;
using Student_Management_Sys.Models;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    void CategoryCreate(CategoryCreate model);
    void CategoryDelete(int id);
}
public class CategoryService : ICategoryService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public CategoryService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories;
    }

    public Category GetById(int id)
    {
        return getCategory(id);
    }
    public void CategoryCreate(CategoryCreate model)
    {
        // validate
        if (_context.Categories.Any(x => x.CategoryName == model.CategoryName))
            throw new AppException("CategoryName '" + model.CategoryName + "' is already taken");

        // map model to new user object
        var category = _mapper.Map<Category>(model);


        // save student
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void CategoryDelete(int id)
    {
        var category = getCategory(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

     private Category getCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null) throw new KeyNotFoundException("Category not found");
        return category;
    }

    
}

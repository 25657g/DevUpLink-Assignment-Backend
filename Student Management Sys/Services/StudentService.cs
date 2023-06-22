namespace Student_Management_Sys.Services;
using AutoMapper;
using Student_Management_Sys.Entities;
using Student_Management_Sys.Helpers;
using Student_Management_Sys.Models;

    public interface IStudentService
{
    IEnumerable<Student> GetAll();
    Student GetById(int id);
    void StudentRegister(StudentRegister model);
    void StudentUpdate(int id, StudentUpdate model);
    void StudentDelete(int id);
}

public class StudentService : IStudentService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public StudentService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public IEnumerable<Student> GetAll()
    {
        return _context.Students;
    }

    public Student GetById(int id)
    {
        return getStudent(id);
    }

    public void StudentRegister(StudentRegister model)
    {
        // validate
        if (_context.Students.Any(x => x.StudentName == model.StudentName))
            throw new AppException("StudentName '" + model.StudentName + "' is already taken");

        // map model to new user object
        var student = _mapper.Map<Student>(model);


        // save student
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void StudentUpdate(int id, StudentUpdate model)
    {
        var student = getStudent(id);

        // validate
        if (model.StudentName != student.StudentName && _context.Students.Any(x => x.StudentName == model.StudentName))
            throw new AppException("StudentName '" + model.StudentName + "' is already taken");



        // copy model to user and save
        _mapper.Map(model, student);
        _context.Students.Update(student);
        _context.SaveChanges();
    }

    public void StudentDelete(int id)
    {
        var student = getStudent(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
    }

    // helper methods

    private Student getStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null) throw new KeyNotFoundException("User not found");
        return student;
    }


}
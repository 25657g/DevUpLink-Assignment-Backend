using System.ComponentModel.DataAnnotations;

namespace Student_Management_Sys.Models;

public class StudentRegister
{
    [Required]
    public int StudentIndex { get; set; }

    [Required]
    public string StudentName { get; set; }

    [Required]
    public string StudentBirthDate { get; set; }

    [Required]
    public string StudenRegtDate { get; set; }
}

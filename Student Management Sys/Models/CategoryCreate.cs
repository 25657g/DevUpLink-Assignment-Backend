using System.ComponentModel.DataAnnotations;

namespace Student_Management_Sys.Models;

    public class CategoryCreate
{ 

    [Required]
    public string CategoryName { get; set; }

    [Required]
    public int AgeLimit { get; set; }

 }


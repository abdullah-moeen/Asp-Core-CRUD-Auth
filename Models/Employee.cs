using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE_CRUD.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Employee Code")]
        public string EmpCode { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Position")]
        public string Position { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Office Location")]
        public string OfficeLocation { get; set; }
    }
}

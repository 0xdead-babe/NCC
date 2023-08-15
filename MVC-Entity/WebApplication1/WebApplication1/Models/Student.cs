using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required")]
        [StringLength(100, MinimumLength =6, ErrorMessage ="Name can be in between 6 to 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        [Range(18, 26, ErrorMessage ="Age has to be in between 18 to 26")]
        public int Age { get; set; }
    }
}

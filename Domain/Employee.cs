using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? SurName { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int ProgrammingLangId { get; set; }
        [Required]
        [Range(18, 60)]
        public int? Age { get; set; }
        [Required]
        public string? Gender { get; set; }

        public string? Department { get; set; }

        public string? ProgrammingLang { get; set; }

    }
}

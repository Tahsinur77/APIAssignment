using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIAssignment.Models.Entities
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public int DeptId { get; set; }
    }
}
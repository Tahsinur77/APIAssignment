using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIAssignment.Models.Entities
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
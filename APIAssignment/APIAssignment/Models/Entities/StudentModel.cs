using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAssignment.Models.Entities
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public int DeptId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAssignment.Models.Entities
{
    public class StudentDeptModel:StudentModel
    {
        public  DepartmentModel Department { get; set; }
    }
}
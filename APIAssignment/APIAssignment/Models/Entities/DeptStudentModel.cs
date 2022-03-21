using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAssignment.Models.Entities
{
    public class DeptStudentModel:DepartmentModel
    {
        public List<StudentModel> students { get; set; }

        public DeptStudentModel()
        {
            students = new List<StudentModel>();
        }
    }
}
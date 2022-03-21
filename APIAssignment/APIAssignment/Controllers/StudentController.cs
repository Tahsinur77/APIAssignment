using APIAssignment.Models.Database;
using APIAssignment.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAssignment.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/Student/Create")]
        [HttpPost]
        public HttpResponseMessage Create(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentModel, Student>());
                var mapper = new Mapper(config);
                var student = mapper.Map<Student>(studentModel);

                APIAssignmentEntities db = new APIAssignmentEntities();
                db.Students.Add(student);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [Route("api/Student/ShowAll")]
        [HttpGet]
        public HttpResponseMessage ShowAll()
        {
            APIAssignmentEntities db = new APIAssignmentEntities();
            var students = db.Students.ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = new Mapper(config);
            var studentModel = mapper.Map<List<StudentModel>>(students);
            return Request.CreateResponse(HttpStatusCode.OK, studentModel);
        }

        [Route("api/Student/Show/{id}")]
        [HttpGet]
        public HttpResponseMessage Show(int id)
        {
            APIAssignmentEntities db = new APIAssignmentEntities();
            var student = (from x in db.Students
                        where x.Id.Equals(id)
                        select x).FirstOrDefault();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = new Mapper(config);
            var studentModel = mapper.Map<StudentModel>(student);
            return Request.CreateResponse(HttpStatusCode.OK, studentModel);
        }

        [Route("api/Student/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            APIAssignmentEntities db = new APIAssignmentEntities();
            var student = (from x in db.Students
                        where x.Id.Equals(id)
                        select x).FirstOrDefault();

            db.Students.Remove(student);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        [Route("api/Student/Edit")]
        [HttpPut]
        public HttpResponseMessage Edit(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                APIAssignmentEntities db = new APIAssignmentEntities();
                var OldStu = (from x in db.Students
                               where x.Id.Equals(studentModel.Id)
                               select x).FirstOrDefault();

                var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentModel, Student>());
                var mapper = new Mapper(config);
                var stu = mapper.Map<Student>(studentModel);

                db.Entry(OldStu).CurrentValues.SetValues(stu);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Edited");
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}

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
    public class DepartmentController : ApiController
    {
        [Route("api/Dept/Create")]
        [HttpPost]
        public HttpResponseMessage Create(DepartmentModel deptModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg=>cfg.CreateMap<DepartmentModel,Department>());
                var mapper = new Mapper(config);
                var dept = mapper.Map<Department>(deptModel);

                APIAssignmentEntities db = new APIAssignmentEntities();
                db.Departments.Add(dept);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [Route("api/Dept/ShowAll")]
        [HttpGet]
        public HttpResponseMessage ShowAll()
        {
            APIAssignmentEntities db = new APIAssignmentEntities();
            var dept = db.Departments.ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentModel>());
            var mapper = new Mapper(config);
            var deptModel = mapper.Map<List<DepartmentModel>>(dept);
            return Request.CreateResponse(HttpStatusCode.OK, deptModel);
        }

        [Route("api/Dept/Show/{id}")]
        [HttpGet]
        public HttpResponseMessage Show(int id)
        {
            APIAssignmentEntities db = new APIAssignmentEntities();
            var dept = (from x in db.Departments
                        where x.Id.Equals(id)
                        select x).FirstOrDefault();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentModel>());
            var mapper = new Mapper(config);
            var deptModel = mapper.Map<DepartmentModel>(dept);
            return Request.CreateResponse(HttpStatusCode.OK, deptModel);
        }

        [Route("api/Dept/Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            APIAssignmentEntities db = new APIAssignmentEntities();
            var dept = (from x in db.Departments
                        where x.Id.Equals(id)
                        select x).FirstOrDefault();

            db.Departments.Remove(dept);
            db.SaveChanges();
            
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

    }
}

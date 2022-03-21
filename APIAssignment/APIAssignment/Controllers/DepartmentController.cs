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
        [Route("api/Create/Dept")]
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
    }
}
